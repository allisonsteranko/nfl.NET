using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SQLite.Net.Attributes;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace nfl.NET.Models
{
    public class Player
    {
        [PrimaryKey]
        public string PlayerId { get; set; }
        [JsonProperty("gsis_name")]
        public string gsis_Name { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("team")]
        public string TeamID { get; set; }
        public string Position { get; set; }
        [JsonProperty("status")]
        public string PlayerStatus { get; set; }
        [JsonProperty("profile_id")]
        public int ProfileID { get; set; }
        [JsonProperty("profile_url")]
        public string ProfileURL { get; set; }
        [JsonProperty("number")]
        public int UniformNumber { get; set; }
        [JsonProperty("birthdate")]
        public string BirthdateString { get; set; }
        [JsonIgnore]
        public DateTime? Birthdate { get; set; }
        public string College { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        [JsonProperty("years_pro")]
        public int YearsPro { get; set; }
    }
}
