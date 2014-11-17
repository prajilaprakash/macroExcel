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

namespace Tracker
{
    /// <summary>
    /// Interaction logic for UserAccessControl.xaml
    /// </summary>
    public partial class UserAccessControl : Window
    {
        public UserAccessControl()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            resetAll();
        }

        //Sow all users reporting to logged in user
        private void ShowAll_Checked(object sender, RoutedEventArgs e)
        {
            string field;
            string query;
            string user;

            user = userControls.loggedinUser;
            dbmodule dbm = new dbmodule();

            field = "user_name";
            query = "SELECT user_name FROM tracker.tc_user_details WHERE user_ro = '" + user + "';";
            dbm.fillComboBox(request_ddl, field, query);

            ta_name_value.Text = "";
            ta_email_value.Text = "";
            ta_designation_value.Text = "";

            cancelToReset();
        }

        //show only users that needs approval to access
        private void ShowAll_Unchecked(object sender, RoutedEventArgs e)
        {
            ta_name_value.Text = "";
            ta_email_value.Text = "";
            ta_designation_value.Text = "";

            showPending();
            cancelToReset();
        }

        //Method which will return full name of the selected username
        public string getFullName(string username)
        {
            string fullName = "";

            dbmodule dbm = new dbmodule();
            fullName = dbm.getSingleValue("SELECT first_name FROM tracker.tc_user_details WHERE user_name = '" + username + "';");
            fullName = fullName + dbm.getSingleValue("SELECT last_name FROM tracker.tc_user_details WHERE user_name = '" + username + "';");

            return fullName;
        }

        //Method which will return designation of the selected username
        public string getDesignation(string username)
        {
            string designation = "";

            dbmodule dbm = new dbmodule();
            designation = dbm.getSingleValue("SELECT designation FROM tracker.tc_user_details WHERE user_name = '" + username + "';");

            return designation;
        }

        //Method which will return email of the selected username
        public string getEmail(string username)
        {
            string email = "";

            dbmodule dbm = new dbmodule();
            email = dbm.getSingleValue("SELECT user_email FROM tracker.tc_user_details WHERE user_name = '" + username + "';");

            return email;
        }

        //Method to reset everything
        private void resetAll()
        {
            showPending();
            ta_name_value.Text="";
            ta_email_value.Text="";
            ta_designation_value.Text="";

            showAllCheckBox.IsChecked=false;
            resetToCancel();

            revoke_button.IsEnabled = false;
            Approve_Button.IsEnabled = false;
        }

        //Method to show only pending requests
        private void showPending()
        {
            string field;
            string query;
            string user;

            user = userControls.loggedinUser;
            dbmodule dbm = new dbmodule();

            field = "user_name";
            query = "SELECT user_name FROM tracker.tc_user_details WHERE user_status = 'p' AND user_ro = '" + user + "';";
            dbm.fillComboBox(request_ddl, field, query);
        }

        //Method to handle reset button click
        private void Reset_click(object sender, RoutedEventArgs e)
        {
            if ((string)Reset_Button.Content=="Cancel")
            {
                this.Close();
            }
            else if((string)Reset_Button.Content=="Reset")
            {
                resetAll();
            }
        }
        //Method to change Cancel Button to Reset Button
        public void cancelToReset()
        {
            Reset_Button.Content="Reset";
        }
        
        //Method to change Reset Button to Cancel Button
        public void resetToCancel()
        {
            Reset_Button.Content="Cancel";
        }

        private void request_ddl_DropDownClosed(object sender, EventArgs e)
        {
            ta_name_value.Text = getFullName(request_ddl.Text);
            ta_designation_value.Text = getDesignation(request_ddl.Text);
            ta_email_value.Text = getEmail(request_ddl.Text);
            approveRevokeButtonStatus();
            cancelToReset();
        }

        private void Approve_Button_Click(object sender, RoutedEventArgs e)
        {
            dbmodule dbm = new dbmodule();
            dbm.insertToDB("UPDATE `tracker`.`tc_user_details` SET `user_status`='a' WHERE `user_name`='" + request_ddl.Text + "';");
            resetAll();
        }

        private void approveRevokeButtonStatus()
        {
            string status = "";
            string query = "";
            query = "SELECT user_status FROM tracker.tc_user_details WHERE user_name = '" + request_ddl.Text +"';";

            dbmodule dbm = new dbmodule();

            status = dbm.getSingleValue(query);

            //a - active (should be able to log in with this user_name)
			//d - deactivated/deleted (should not be able to log in)
			//p - pending approval (should not be able to login)
			//r - rejected (should not be able to log in)

            switch (status)
            {
                case "":
                break;
                
                case "a":
                    revoke_button.IsEnabled = true;
                    Approve_Button.IsEnabled = false;
                break;

                case "d":

                break;
                
                case "p":
                    revoke_button.IsEnabled = true;
                    Approve_Button.IsEnabled = true;
                break;

                case "r":
                    revoke_button.IsEnabled = false;
                    Approve_Button.IsEnabled = true;
                break;
            }
        }

        private void revoke_button_Click(object sender, RoutedEventArgs e)
        {
            {
                dbmodule dbm = new dbmodule();
                dbm.insertToDB("UPDATE `tracker`.`tc_user_details` SET `user_status`='r' WHERE `user_name`='" + request_ddl.Text + "';");
                resetAll();
            }
        }
    }
}
