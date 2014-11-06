using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tracker.Forms;

namespace Tracker.Forms
{
    /// <summary>
    /// Interaction logic for Login_Request_Window.xaml
    /// </summary>
    public partial class Login_Request_Window : Window
    {
        public Login_Request_Window()
        {
            InitializeComponent();
        }

        private void login_request_window_Closed(object sender, EventArgs e)
        {
            Login_Window lw = new Login_Window();
            lw.Show();
        }

        private void request_button_Click(object sender, RoutedEventArgs e)
        {
            string userinfo;
            string userdetails;
            if (r_password_val.Password==r_confirm_val.Password)
            {
                userinfo = "INSERT INTO `tracker`.`tc_user_info` (`user_name`, `user_pass`) VALUES ('"+ r_username_val.Text +"', '" + (String)r_password_val.Password +"');";
                userdetails = "INSERT INTO `tracker`.`tc_user_details` (`user_name`, `first_name`, `last_name`, `designation`, `user_email`, `user_status`, `user_team`) VALUES ('"+r_username_val.Text+"', '" +r_firstname_val.Text+ "', '" + r_lastname_val.Text + "', '" + r_designation_val.Text + "', '" + r_email_val.Text + "', 'p', ' " + r_team_val.Text + "');";
                dbmodule mod = new dbmodule();
                mod.insertToDB(userinfo);
                mod.insertToDB(userdetails);
                MessageBox.Show("requested successfully");
                reset_form();
            }
            else
            {
                MessageBox.Show("Passwords doesnt match, please reneter your password");
            }
        }

        private void cancel_button_Click(object sender, RoutedEventArgs e)
        {
            if ((String)cancel_button.Content=="Cancel")
            {
                this.Close();
            }
            else if((String)cancel_button.Content=="Reset")
            {
                reset_form();
            }

        }

        public void reset_form()
        {
            r_username_val.Text = "";
            r_password_val.Password = "";
            r_confirm_val.Password = "";
            r_firstname_val.Text = "";
            r_lastname_val.Text = "";
            r_email_val.Text = "";
            r_designation_val.Text = "";
            r_team_val.Text = "";
            r_ro_val.Text = "";
            ro_name.Content = "";
            cancel_button.Content = "Cancel";
            fillAllDropDowns();            
        }

        private void login_request_window_Loaded(object sender, RoutedEventArgs e)
        {
            fillAllDropDowns();
            ro_name.Content = "";
        }

        private void DropDownClosed(object sender, EventArgs e)
        {
            String roname = "";
            dbmodule d = new dbmodule();

            roname = d.getSingleValue("SELECT first_name from tc_user_details WHERE user_name= '" + r_ro_val.Text + "'");
            roname = roname + " " + d.getSingleValue("SELECT last_name from tc_user_details WHERE user_name= '" + r_ro_val.Text + "'");

            ro_name.Content = roname;

            enableRequestBtn();
            resetButnEnabled();
        }

        private void fillAllDropDowns()
        {
            dbmodule dbm = new dbmodule();

            dbm.fillComboBox(r_designation_val, "param_value", "SELECT param_value FROM tc_app_params WHERE param_type='designation'");
            dbm.fillComboBox(r_team_val, "param_value", "SELECT param_value FROM tc_app_params WHERE param_type='team'");
            dbm.fillComboBox(r_ro_val, "user_name", "SELECT user_name FROM tc_user_details WHERE designation IN (SELECT param_value FROM tc_app_params WHERE param_type='designation' AND param_power > 5)");
        }

        private bool isFormVailidated()
        {
            if (r_username_val.Text == "")
            {
                return false;
            }
            else if (r_password_val.Password == "")
            {
                return false;
            }
            else if (r_confirm_val.Password == "")
            {
                return false;
            }
            else if (r_firstname_val.Text == "")
            {
                return false;
            }
            else if (r_lastname_val.Text == "")
            {
                return false;
            }
            else if (r_email_val.Text == "")
            {
                return false;
            }
            else if (r_designation_val.Text == "")
            {
                return false;
            }
            else if (r_team_val.Text == "")
            {
                return false;
            }
            else if (r_ro_val.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void enableRequestBtn()
        {
            if (isFormVailidated())
            {
                request_button.IsEnabled = true;
            }
            else
            {
                request_button.IsEnabled = false;
            }
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            enableRequestBtn();
            resetButnEnabled();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            enableRequestBtn();
            resetButnEnabled();
        }

        private void resetButnEnabled()
        {
            if (r_username_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_password_val.Password != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_confirm_val.Password != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_firstname_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_lastname_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_email_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_designation_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_team_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else if (r_ro_val.Text != "")
            {
                cancel_button.Content = "Reset";
            }
            else
            {
                cancel_button.Content = "Cancel";
            }
        }

    }


}
