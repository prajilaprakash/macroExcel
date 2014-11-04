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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tracker.Forms;

namespace Tracker.Forms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login_Window : Window
    {

        public Login_Window()
        {
            InitializeComponent();
        }

        //General Functions
        private void cancel_toReset()
        {
            cancel_button.Content = "Reset";
        }

        private void login_check()
        {
            if ((username_val.Text != "")&&(password_val.Password != ""))
            {
                login_button.IsEnabled = true;
            }
            else 
            {
                login_button.IsEnabled = false;
            }
        }

        //Events
        private void reset_clicked(object sender, RoutedEventArgs e)
        {
            if ((string)cancel_button.Content == "Reset")
            {
                username_val.Text = "";
                password_val.Password = "";
                login_check();
                cancel_button.Content = "Cancel";
            }
            else if ((string)cancel_button.Content == "Cancel")
            {
                this.Close();
            }  
        }

        private void username_val_TextChanged(object sender, TextChangedEventArgs e)
        {
            cancel_toReset();
            login_check();
        }

        private void password_val_PasswordChanged(object sender, RoutedEventArgs e)
        {
            cancel_toReset();
            login_check();
        }

        private void login_button_Click(object sender, RoutedEventArgs e)
        {
            String nameFromDB;
            String statusFromDB;
            
            dbmodule dbm = new dbmodule();
            
            statusFromDB = dbm.getSingleValue("SELECT user_status FROM tc_user_details WHERE user_name = '" + username_val.Text + "'");
            nameFromDB = dbm.getSingleValue("SELECT user_name FROM tc_user_info WHERE user_name = '" + username_val.Text + "' AND user_pass = '" + password_val.Password.ToString() + "'");
            
            if (nameFromDB==username_val.Text)
            {
                if (statusFromDB == "a")
                {
                    //login()
                    MessageBox.Show("Logged in");
                }
                else if (statusFromDB == "d")
                {
                    //dont login
                    MessageBox.Show("Your account is deactivated, please contact your manager");
                }
                else if (statusFromDB == "p")
                {
                    //dont login
                    MessageBox.Show("Your account is not yer activated. Please contact your manager");
                }
                else if (statusFromDB == "r")
                {
                    //dont login
                    MessageBox.Show("Your request is rejected. Please contact your manager");
                }
            }
            else
            {
                MessageBox.Show("Failed to Log in. Please provice your correct username and password.\n Please request for access if you dont have and account yet.");
            }
        }

        public void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //Login_Request_Window lr = new Login_Request_Window();

            Login_Request_Window lr = new Login_Request_Window();
            lr.Show();
            //this.Close();
        }
    }
}
