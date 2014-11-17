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
    /// Interaction logic for Tracker_Window.xaml
    /// </summary>
    public partial class Tracker_Window : Window
    {
        public Tracker_Window()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Do you want to Logout?";
            string sCaption = "Tracker - Logout";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Exclamation;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    Application.Current.Shutdown();
                    break;
                case MessageBoxResult.No:
                    //Do nothing
                    break;
            }
        }

        private void show_ResourceWindow(object sender, RoutedEventArgs e)
        {
            Tracker.UserAccessControl uac = new UserAccessControl();
            uac.Show();
        }
    }
}
