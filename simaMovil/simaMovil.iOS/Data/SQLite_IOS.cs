using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using simaMovil.Data;
using SQLite;
using System.IO;
using Xamarin.Forms;
using simaMovil.iOS.Data;

[assembly: Dependency(typeof(SQLite_IOS))]

namespace simaMovil.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "Testdb.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFileName);
            var conn = new SQLiteConnection(path);

            return conn;
        }

    }
}