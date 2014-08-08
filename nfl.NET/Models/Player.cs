using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace nfl.NET.Models
{
    public class Player
    {
        [PrimaryKey]
        public string PlayerId { get; set; }
        public string gsis_Name { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey(typeof(Team))]
        public string TeamID { get; set; }
        [ForeignKey(typeof(PlayerPosition))]
        public int PositionID { get; set; }
        [ForeignKey(typeof(PlayerStatus))]
        public string PlayerStatus { get; set; }
        public int ProfileID { get; set; }
        public string ProfileURL { get; set; }
        public int UniformNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string College { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int YearsPro { get; set; }


        [OneToOne]
        public PlayerPosition Position{get;set;}
        [OneToOne]
        public Team Team { get; set; }
        [OneToOne]
        public PlayerStatus Status { get; set; }
    }
}
