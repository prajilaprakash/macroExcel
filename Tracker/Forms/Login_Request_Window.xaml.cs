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
            this.Close();
            
        }
    }
}
