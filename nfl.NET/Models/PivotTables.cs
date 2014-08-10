using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
namespace nfl.NET.Models
{
    public class StatCountingStats
    {
        [ForeignKey(typeof(Stat))]
        public int StatId { get; set; }
        [ForeignKey (typeof(CountingStats))]
        public int CountingStatId { get; set; }
    }
}
