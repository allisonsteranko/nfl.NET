using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLite.Net.Platform.Win32;

namespace nfl.NET.Models
{
    public class DatabaseContext
    {
        private SQLitePlatformWin32 _platform = new SQLitePlatformWin32();
        private string _defaultFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\nfldb.db";

        public SQLiteConnection GetDBConn()
        {
            return new SQLiteConnection(_platform, _defaultFilePath);
        }
    }
}
