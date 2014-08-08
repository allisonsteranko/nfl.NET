using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace nfl.NET.Models
{
    public class Game
    {
        public string gsis_id { get; set; }
        public string GameKey { get; set; }
        public DateTime StartTime { get; set; }
        public int Week { get; set; }
        [ForeignKey(typeof(GameDay))]
        public int GameDayID { get; set; }
        public int SeasonYear { get; set; }
        [ForeignKey(typeof(SeasonPhase))]
        public int SeasonPhaseID { get; set; }
        public bool Finished { get; set; }
        [ForeignKey(typeof(Team))]
        public string HomeTeamID { get; set; }
        public int HomeScore { get; set; }
        public int HomeScore_Q1 { get; set; }
        public int HomeScore_Q2 { get; set; }
        public int HomeScore_Q3 { get; set; }
        public int HomeScore_Q4 { get; set; }
        public int HomeScore_Q5 { get; set; }
        public int HomeTurnovers { get; set; }
        [ForeignKey(typeof(Team))]
        public string AwayTeamID { get; set; }
        public int AwayScore { get; set; }
        public int AwayScore_Q1 { get; set; }
        public int AwayScore_Q2 { get; set; }
        public int AwayScore_Q3 { get; set; }
        public int AwayScore_Q4 { get; set; }
        public int AwayScore_Q5 { get; set; }
        public int AwayTurnovers { get; set; }

        [OneToMany]
        public List<Team> Teams { get; set; }
        [OneToOne]
        public SeasonPhase SeasonPhase { get; set; }
        [OneToOne]
        public GameDay GameDay { get; set; }

    }
}
