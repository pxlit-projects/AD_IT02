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
using desktopapp;
using desktopapp.classes;

namespace desktopapp
{
    public partial class MainWindow : Window
    {
        private Persoon test;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message,"error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login()
        {
            test = UserDB.GetLogin(txtNaam.Text, txtWachtwoord.Password);
            if (test == null)
            {
                MessageBox.Show("Gebruikersnaam/Wachtwoord is fout.");
            }
            else
            {
                int functie = test.functie;
                hulpverlener hulp = new hulpverlener();
                hulp.Show();
                Close();
            }
        }
    }
}
