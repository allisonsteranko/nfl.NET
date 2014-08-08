using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nfl.NET.Models
{
    public class Team
    {
        [PrimaryKey]
        public string TeamId { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
    }
}
