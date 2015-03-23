using System;
using System.Collections.Generic;
using System.Configuration;
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
using Finah;

namespace desktopapp
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

            try
            {
                test = UserDB.GetLogin("illy", "illy");
                if (test == null)
                {
                    MessageBox.Show("verkeerd error");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("fuckt");
            }

        }

        private void knop_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
