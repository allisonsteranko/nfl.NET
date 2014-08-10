using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nfl.NET.Models
{
    public class Stat
    {
        public int StatId { get; set; }
        public int? StatCategoryId { get; set; }
        public int? YardageTypeId { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }

        [ManyToMany(typeof(StatCountingStats))]
        public List<CountingStats> CountingStats {get;set;}

    }
}
