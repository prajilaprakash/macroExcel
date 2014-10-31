using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Tracker.Modules
{
    class dbmodule
    {
        object connection;
        string connectionString;

        public void connectmysql()
        {
            connectionString="";
            connection = new MySqlConnection();
        }
    }
}
