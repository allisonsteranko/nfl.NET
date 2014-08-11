using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nfl.NET.Helpers
{
    public class TimeHelpers
    {
        public string ConvertToMinSec(int seconds)
        {
            var timespan = TimeSpan.FromSeconds(seconds);
            return timespan.ToString(@"mm\:ss");
        }

        public int ConvertToSeconds(string MMss)
        {
            var splitStr = MMss.Split(':');
            var minSecs = int.Parse(splitStr[0]) * 60;
            var secSecs = int.Parse(splitStr[1]);

            return minSecs + secSecs;
        }
    }
}
