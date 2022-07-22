using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace simaMovil.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();


    }
}
