using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nfl.NET.Models
{

    public class GameDay
    {
        public int GameDayID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class SeasonPhase
    {
        public int SeasonPhaseID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class GamePhase
    {
        public int GamePhaseID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class PlayerStatus
    {
        public int PlayerStatusID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class PlayerPosition
    {
        public int PositionID { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

    public class FieldPosition
    {
        public int FieldPositionID { get; set; }
        public int Position { get; set; }
        public string Text { get; set; }
    }

    public class YardageType
    {
        public int YardageTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class StatCategory
    {
        public int StatCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get;set;}
    }

    public class CountingStats
    {
        public int CountingStatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ManyToMany(typeof(StatCountingStats))]
        public List<Stat> Stats { get; set; }
    }

}
