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
        public String getSingleValue(String query)
        {
            String name = "";
            MySqlConnectionStringBuilder conString = new MySqlConnectionStringBuilder();
            conString.Server = "localhost";
            conString.Database = "tracker";
            conString.UserID = "user";
            conString.Password = "";
            MySqlConnection connection = new MySqlConnection(conString.ToString());
            MySqlDataReader dr;
            MySqlCommand cmd = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                name = dr.GetString(0); 
                connection.Close();
            }
            catch(MySqlException em)
            {
                Console.WriteLine(em.ToString());
            }
            finally
            {
                connection.Close();
            }
            return name;
        }
    }
}
