using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace nfl.NET.Models
{
    public class Drive
    {
        public int DriveId { get; set; }
        [ForeignKey(typeof(Game))]
        public string gsis_id { get; set; }
        [JsonProperty("fds")]
        public int FirstDowns { get; set; }
        public string Result { get; set; }
        [JsonProperty("penyds")]
        public int PenaltyYards { get; set; }
        [JsonProperty("postime")]
        public string TimeOfPossession { get; set; }
        public int? TimeOfPossessionSeconds { get; set; }
        [JsonProperty("numplays")]
        public int PlayCount { get; set; }
        [JsonProperty("posteam")]
        public string PossestionTeamId {get;set;}
        
        [JsonIgnore]
        public GameTime StartTime { get; set; }
        [JsonIgnore]
        public GameTime EndTime { get; set; }
        [JsonIgnore]
        public FieldPosition StartFieldPos { get; set; }
        [JsonIgnore]
        public FieldPosition EndFieldPos { get; set; }
        
        [JsonIgnore]
        [OneToMany]
        public List<Play> Plays { get; set; }
    }
}
