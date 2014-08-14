using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Platform.Win32;
using SQLite.Net;
using SQLiteNetExtensions;
using nfl.NET.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace nfl.NET
{
    public class CreateDatabase
    {
        private SQLitePlatformWin32 _platform = new SQLitePlatformWin32();
        private string _defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\nfldb.db";
        
        public void SetFilePath (string filepath)
        {
            if (!string.IsNullOrWhiteSpace(filepath))
            {
                _defaultFilePath = filepath;
            }
        }
        public void SetupDatabase()
        {
            if (!File.Exists(_defaultFilePath))
            {
                using (var conn = new SQLiteConnection(_platform, _defaultFilePath))
                {
                    conn.CreateTable<SeasonPhase>();
                    conn.CreateTable<GamePhase>();
                    conn.CreateTable<GameTime>();
                    conn.CreateTable<FieldPosition>();
                    conn.CreateTable<GameDay>();
                    conn.CreateTable<PlayerStatus>();
                    conn.CreateTable<Team>();
                    conn.CreateTable<Game>();
                    conn.CreateTable<Drive>();
                    //conn.CreateTable<Play>();
                    conn.CreateTable<Player>();
                    //conn.CreateTable<PlayerPlay>();

                    SeedDatabase(conn);
                }
            }
        }

        public void SeedDatabase(SQLiteConnection conn)
        {
            string TeamSeed = GetSeedString("teams.txt");
            var teamlist = JArray.Parse(TeamSeed);
            {
                foreach (JObject team in teamlist)
                {
                    var _team = JsonConvert.DeserializeObject<Team>(team.ToString());
                    conn.Insert(_team);
                }
            }
            TeamSeed = null;

            string PlayerSeed = GetSeedString("players.txt");
            var PlayerList = JObject.Parse(PlayerSeed);
            foreach (var jsonplayerobject in PlayerList)
            {
                var jsonplayer = jsonplayerobject.Value;
                try
                {
                    var player = JsonConvert.DeserializeObject<Player>(jsonplayer.ToString());
                    player.PlayerId = jsonplayerobject.Key;
                    if (!string.IsNullOrWhiteSpace(player.BirthdateString))
                    {
                        player.Birthdate = DateTime.Parse(player.BirthdateString);
                    }
                    conn.Insert(player);
                }
                catch (JsonSerializationException ex)
                {

                }
            }
            PlayerSeed = null;




            string StatMapSeed;
            string CategorySeed;
            string CountingStatsSeed;
            string FieldPositionSeed;
            string GameTimeSeed;
            string SeasonPhaseSeed;
            string GamePhaseSeed;
            string GameDaySeed;
            string PlayerStatusSeed;



        }

        public string GetSeedString(string filename)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var streambase = assembly.GetName().Name + ".Resources.";

            using (Stream playerstream = assembly.GetManifestResourceStream(streambase + filename))
            using (StreamReader sr = new StreamReader(playerstream))
            {
                return sr.ReadToEnd();
            }
        }

    }
}
