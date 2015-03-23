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

           

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                test = UserDB.GetLogin(txtNaam.Text, txtWachtwoord.Text);
                if (test == null)
                {
                    MessageBox.Show("Gebruikersnaam/Wachtwoord is fout.");
                }
                else
                {
                    hulpverlener hulp= new hulpverlener();
                    hulp.Show();
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connectie niet mogelijk.");
            }
        }
    }
}
