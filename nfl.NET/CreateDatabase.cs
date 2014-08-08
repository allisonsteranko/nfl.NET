using System;
using System.Collections.Generic;
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
        private string _defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        public void CreateDatabase()
        {           
            using (var conn = new SQLiteConnection(_platform, _defaultFilePath))
            {
                conn.CreateTable<Team>();
                conn.CreateTable<Game>();
                conn.CreateTable<PlayerPosition>();
                conn.CreateTable<Player>();
            }
        }
    }
}
