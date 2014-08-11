using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace nfl.NET.Models
{
    public class Drive
    {
        public int DriveId { get; set; }
        [ForeignKey(typeof(Game))]
        public string gsis_id { get; set; }
        public int FirstDowns { get; set; }
        public string result { get; set; }
        public int PenaltyYards { get; set; }
        public string TimeOfPossession { get; set; }
        public int TimeOfPossessionSeconds { get; set; }
        public int PlayCount { get; set; }

        public GameTime StartTime { get; set; }
        public GameTime EndTime { get; set; }

        public FieldPosition StartFieldPos { get; set; }
        public FieldPosition EndFieldPos { get; set; }

        public List<Play> Plays { get; set; }
    }
}
