using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using nfl.NET.Models;
using System.Net;
using System.IO;

namespace nfl.NET.NFLDataAccess
{
    public class GameParser
    {
        #region PROPERTIES
        private static string _baseURL = "http://www.nfl.com/liveupdate/game-center/";
        private static string _URLsuffix = "_gtd.json";
        #endregion
        
        public string GetGameFeed(string gameID)
        {
            string JsonString;
            StringBuilder urlbuilder = new StringBuilder(_baseURL);
            urlbuilder.Append(gameID + "/");
            urlbuilder.Append(gameID + _URLsuffix);
            try
            {
                var request = WebRequest.Create(urlbuilder.ToString());
                request.Timeout = 3000;
                using (var response = request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        var readStream = new StreamReader(responseStream);
                        //stringify data
                        JsonString = readStream.ReadToEnd();
                        responseStream.Close();
                        response.Close();
                        return JsonString;
                    }
                }
            }
            catch (WebException ex)
            {
                JsonString = ex.Message;
                return JsonString;
            }
        }

        public Game ParseGeneralGameData(string GameFeed, string GameKey)
        {
            var game = JObject.Parse(GameFeed);
            
            var homestats = (JObject)game.SelectToken(GameKey).SelectToken("home");
            var awaystats = (JObject)game.SelectToken(GameKey).SelectToken("away");
            
            var homescores = (JObject)homestats.SelectToken("score");
            var awayscores = (JObject)awaystats.SelectToken("score");


            var _thisGame = new Game();
                _thisGame.AwayTeamID = awaystats.SelectToken("abbr").Value<string>();
                _thisGame.HomeTeamID = homestats.SelectToken("abbr").Value<string>();
                _thisGame.GameKey = GameKey;
                _thisGame.gsis_id = GameKey;
                _thisGame.Finished = (game.SelectToken(GameKey).SelectToken("qtr").Value<string>() == "Final");
                _thisGame.HomeScore_Q1 = homescores.SelectToken("1").Value<int>();
                _thisGame.HomeScore_Q2 = homescores.SelectToken("2").Value<int>();
                _thisGame.HomeScore_Q3 = homescores.SelectToken("3").Value<int>();
                _thisGame.HomeScore_Q4 = homescores.SelectToken("4").Value<int>();
                _thisGame.HomeScore_Q5 = homescores.SelectToken("5").Value<int>();
                _thisGame.HomeScore = homescores.SelectToken("T").Value<int>();
                _thisGame.AwayScore_Q1 = awayscores.SelectToken("1").Value<int>();
                _thisGame.AwayScore_Q2 = awayscores.SelectToken("2").Value<int>();
                _thisGame.AwayScore_Q3 = awayscores.SelectToken("3").Value<int>();
                _thisGame.AwayScore_Q4 = awayscores.SelectToken("4").Value<int>();
                _thisGame.AwayScore_Q5 = awayscores.SelectToken("5").Value<int>();
                _thisGame.AwayScore = awayscores.SelectToken("T").Value<int>();
                _thisGame.HomeTurnovers = homestats.SelectToken("to").Value<int>();
                _thisGame.AwayTurnovers = awaystats.SelectToken("to").Value<int>();
            return _thisGame;
        }

        public List<Drive> ParseDrives(string GameFeed, string GameKey)
        {
            var DriveList = new List<Drive>();
            var game = JObject.Parse(GameFeed);
            var jsonDrives = (JObject)game.SelectToken(GameKey).SelectToken("drives");

            foreach (var drive in jsonDrives)
            {
                //dosomethinghere
            }

            return DriveList;
        }

        //public List<Play> ParsePlays(string GameFeed)
        //{

        //}
    }
}
