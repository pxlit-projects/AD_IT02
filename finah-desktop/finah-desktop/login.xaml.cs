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
using System.Web.Security;

namespace finah_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users test;
        public MainWindow()
        {
            InitializeComponent();
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                test = UserDB.GetLogin(usr.Text, ww.Text);
                if (test == null)
                {
                    MessageBox.Show("verkeerd error");
                }
                else
                {
                    MessageBox.Show("gelukt");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("fuckt");
            }
            

        }
    }

}

