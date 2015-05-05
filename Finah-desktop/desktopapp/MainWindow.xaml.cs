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
        private Logger logger = new Logger();

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
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login()
        {
            try
            {
                gebruiker = dal.getGebruiker(txtNaam.Text, txtWachtwoord.Password);
                if (gebruiker == null)
                {
                    MessageBox.Show("Gebruikersnaam/Wachtwoord is fout.");
                }
                else
                {
                    switch (gebruiker.functieID)
                    {
                        case 1:
                            AdminPaneel admin = new AdminPaneel();
                            admin.Show();
                            break;
                        case 2:
                            onderzoeker onderzoeker = new onderzoeker();
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
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)//Inloggen bij enter te duwen
        {
            try
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
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }  
        }
    }
}
