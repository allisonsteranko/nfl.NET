using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nfl.NET.NFLDataAccess;
using nfl.NET.Models;
using nfl.NET.Helpers;

namespace ConsoleApplication1
{
    class Program
    {
        private static GameParser _ctxGames = new GameParser();
        private static TimeHelpers time = new TimeHelpers();
        static void Main(string[] args)
        {
            var gameID = "2012010101";
            var GameFeed = _ctxGames.GetGameFeed(gameID);
            var GameData = _ctxGames.ParseGeneralGameData(GameFeed, gameID);
            var GameDrives = _ctxGames.ParseDrives(GameFeed, gameID);
            Console.WriteLine("Home Score: " + GameData.HomeScore);
            Console.WriteLine("Away Score: " + GameData.AwayScore);
            Console.WriteLine("Time of posession test - 643 seconds = " + time.ConvertToMinSec(643));
            Console.WriteLine("Time of possesson reverse test - 10:43 = " + time.ConvertToSeconds("10:43").ToString() + " seconds");
        }
    }
}
