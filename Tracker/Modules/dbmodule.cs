using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


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

        public void fillComboBox(System.Windows.Controls.ComboBox combobox,String field_name, String query)
        {
            MySqlConnectionStringBuilder conString = new MySqlConnectionStringBuilder();
            conString.Server = "localhost";
            conString.Database = "tracker";
            conString.UserID = "user";
            conString.Password = "";
            MySqlConnection connection = new MySqlConnection(conString.ToString());
            //MySqlDataReader dr;
            //MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);
            DataSet ds = new DataSet();

            try
            {
                connection.Open();
                da.Fill(ds);

                combobox.ItemsSource = ds.Tables[0].DefaultView;
                combobox.DisplayMemberPath = ds.Tables[0].Columns[field_name].ToString();
                combobox.SelectedValuePath = ds.Tables[0].Columns[field_name].ToString();
                //dr = cmd.ExecuteReader();
                //dr.Read();
                //combobox.Items.Add("--select--");
                //for (int i = 0; i < 1; i++)
                //{
                //   combobox.Items.Add(dr.GetString(i));
                //}
                connection.Close();
            }
            catch (MySqlException em)
            {
                Console.WriteLine(em.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public int insertToDB(String query)
        {
            MySqlConnectionStringBuilder conString = new MySqlConnectionStringBuilder();

            conString.Server = "localhost";
            conString.UserID = "user";
            conString.Password = "";
            conString.Database = "tracker";

            MySqlConnection con = new MySqlConnection(conString.ToString());

            MySqlCommand cmd = new MySqlCommand(query, con);

            int y = 0;

            try
            {
                con.Open();
                y = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {

            }
            return y;
        }

    }
}
