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

namespace Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
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

        private void cancel_toReset(object sender, DataTransferEventArgs e)
        {

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
    }
}
