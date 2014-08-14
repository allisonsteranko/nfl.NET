using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nfl.NET.NFLDataAccess;
using nfl.NET.Models;
using nfl.NET.Helpers;
using nfl.NET;
using System.Data.SQLite;

namespace ConsoleApplication1
{
    class Program
    {
        private static GameParser _ctxGames = new GameParser();
        private static TimeHelpers time = new TimeHelpers();
        private static CreateDatabase dbseeder = new CreateDatabase();
        private static DatabaseContext _ctxdb = new DatabaseContext();

        static void Main(string[] args)
        {
            //var gameID = "2012010101";
            //var GameFeed = _ctxGames.GetGameFeed(gameID);
            //var GameData = _ctxGames.ParseGeneralGameData(GameFeed, gameID);
            //var GameDrives = _ctxGames.ParseDrives(GameFeed, gameID);
            //Console.WriteLine("Home Score: " + GameData.HomeScore);
            //Console.WriteLine("Away Score: " + GameData.AwayScore);
            //Console.WriteLine("Time of posession test - 3554 seconds = " + time.ConvertToMinSec(3554));
            //Console.WriteLine("Time of possesson reverse test - 59:54 = " + time.ConvertToSeconds("59:54").ToString() + " seconds");
            //dbseeder.SetupDatabase();

            var PhillyPlayers = new List<Player>();
            using (var conn = _ctxdb.GetDBConn())
            {
                var team = conn.Table<Team>().FirstOrDefault(x => x.TeamId == "PHI");
                Console.WriteLine("Roster - {0} {1}", team.City, team.Name);
                PhillyPlayers = conn.Table<Player>().Where(x => x.TeamID == "PHI").OrderBy(x => x.UniformNumber).ToList();
            }

            foreach (var player in PhillyPlayers)
            {
                Console.WriteLine("{2} {0} - {1}", player.FullName, player.Position, player.UniformNumber);
            }
        }
            
    }
}
