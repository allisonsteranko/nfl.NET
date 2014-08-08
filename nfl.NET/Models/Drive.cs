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

    }
}
