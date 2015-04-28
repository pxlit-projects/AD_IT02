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
        public static Persoon gebruiker;
        private DAL dal = new DAL();
        public Persoon login;

        public MainWindow()
        {
            InitializeComponent();
            gebruiker = null;
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
            gebruiker = dal.ZoekGebruiker(txtNaam.Text, txtWachtwoord.Password);
            if (gebruiker == null)
            {
                MessageBox.Show("Gebruikersnaam/Wachtwoord is fout.");
            }
            else
            {
                login = gebruiker;
                
                switch (gebruiker.functie)
                {
                    case 1:
                        AdminPaneel admin = new AdminPaneel();
                        admin.Show();
                        break;
                    case 2:
                        hulpverlener onderzoeker = new hulpverlener();
                        onderzoeker.Show();
                        break;
                    default:
                        hulpverlener hulpverlener = new hulpverlener();
                        hulpverlener.Show();
                        break;
                }
                Close();
            }
        }

        private void txtWachtwoord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    Login();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error");
                }  
            }
           
        }
    }
}
