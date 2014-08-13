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
                    conn.CreateTable<PlayerPosition>();
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
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string PlayerSeed;
            string TeamSeed;
            string StatMapSeed;
            string CategorySeed;
            string CountingStatsSeed;
            string FieldPositionSeed;
            string GameTimeSeed;
            string PlayerPositionSeed;
            string SeasonPhaseSeed;
            string GamePhaseSeed;
            string GameDaySeed;
            string PlayerStatusSeed;
            
            using (Stream playerstream = assembly.GetManifestResourceStream(assembly.GetName().Name + ".Resources.players.txt"))
            using (StreamReader sr = new StreamReader(playerstream))
            {
                PlayerSeed = sr.ReadToEnd();
            }
            var PlayerList = JObject.Parse(PlayerSeed);
            foreach (var jsonplayerobject in PlayerList)
            {
                var jsonplayer = jsonplayerobject.Value;
                try
                {
                    var player = JsonConvert.DeserializeObject<Player>(jsonplayer.ToString());
                    conn.Insert(player, typeof(Player));
                }
                catch (JsonSerializationException ex)
                {

                }


            }

        }
    }
}
