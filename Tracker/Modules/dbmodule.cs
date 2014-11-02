using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Tracker
{
    class dbmodule
    {
        public void getSingleValue()
        {
            MySqlConnectionStringBuilder conString = new MySqlConnectionStringBuilder();
            conString.Server = "localhost";
            conString.Database = "tracker";
            conString.UserID = "user";
            conString.Password = "user";
            MySqlConnection connection = new MySqlConnection();
            try
            {
                connection.Open();
            }
            catch(MySqlException em)
            {
                Console.WriteLine(em.ToString());
            }
        }
    }
}
