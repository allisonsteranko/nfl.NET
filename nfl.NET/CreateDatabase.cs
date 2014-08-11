using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Platform.Win32;
using SQLite.Net;
using SQLiteNetExtensions;
using nfl.NET.Models;

namespace nfl.NET
{
    public class CreateDatabase
    {
        private SQLitePlatformWin32 _platform = new SQLitePlatformWin32();
        private string _defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "nfldb.db";
        
        public void SetFilePath (string filepath)
        {
            if (!string.IsNullOrWhiteSpace(filepath))
            {
                _defaultFilePath = filepath;
            }
        }
        public void SetupDatabase()
        {
            if (!File.Exists(_defaultFilePath))
            {
                using (var conn = new SQLiteConnection(_platform, _defaultFilePath))
                {
                    conn.CreateTable<SeasonPhase>();
                    conn.CreateTable<GamePhase>();
                    conn.CreateTable<GameTime>();
                    conn.CreateTable<FieldPosition>();
                    conn.CreateTable<PlayerPosition>();
                    conn.CreateTable<GameDay>();
                    conn.CreateTable<PlayerStatus>();
                    conn.CreateTable<Team>();
                    conn.CreateTable<Game>();
                    conn.CreateTable<Drive>();
                    conn.CreateTable<Play>();
                    conn.CreateTable<Player>();
                    conn.CreateTable<PlayerPlay>();
                }
            }
        }

        public void SeedDatabase()
        {

        }
    }
}
