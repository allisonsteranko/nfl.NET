using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;

namespace nfl.NET.Models
{
    public class GameTime
    {
        [PrimaryKey]
        public int Seconds { get; set; }
        [ForeignKey(typeof(GamePhase))]
        public int GamePhaseID { get; set; }
        public string FriendlyTime { get; set; }

        [ManyToOne]
        public GamePhase Phase { get; set; }
    }
}
