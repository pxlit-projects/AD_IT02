using System;
using System.Collections.Generic;
using System.Globalization;
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
using desktopapp.classes;
using desktopapp;


namespace desktopapp
{
    /// <summary>
    /// Interaction logic for MijnAccount.xaml
    /// </summary>
    public partial class MijnAccount : Window
    {
        
       private Boolean aangepast = false;
        public MijnAccount()
        {
            
            InitializeComponent();
            TextboxEnable(false);
            GegevensUitlezen();
            




        }

        private void aanpassen_Click(object sender, RoutedEventArgs e)
        {
            if (aangepast == false)
            {
                TextboxEnable(true);
                aanpassen.Content = "Updaten";
                aangepast = true;
            }
            else
            {
                if(wachtwoord.Text != bevestig.Text)
                {
                    MessageBox.Show("Wachtwoorden komen niet overeen.");
                }
                else
                {
                    aangepast = false;
                    GegevensUpdaten();
                    try
                    {
                       //AL.insertPersoon(MainWindow.gebruiker);
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                   aanpassen.Content = "Aanpassen";
                    TextboxEnable(false);
                    MessageBox.Show("Aanpassingen zijn succesvol opgeslagen.");
                }
                

            }
        }

        public void TextboxEnable(Boolean b)
        {
           naam.IsEnabled = b;
            voornaam.IsEnabled = b;
            geboorte.IsEnabled = b;
            postcode.IsEnabled = b;
            geslacht.IsEnabled = b;
            straat.IsEnabled = b;
            login.IsEnabled = b;
            wachtwoord.IsEnabled = b;
            bevestig.IsEnabled = b;
            telefoon.IsEnabled = b;
            gsm.IsEnabled = b;
            bedrijf.IsEnabled = b;
            
        }

        public void GegevensUitlezen()
        {
            naam.Text = MainWindow.gebruiker.naam.ToString();
            voornaam.Text = MainWindow.gebruiker.voornaam.ToString();
            geboorte.Text = MainWindow.gebruiker.geboortejaar.ToString(CultureInfo.CurrentCulture);
            postcode.Text = MainWindow.gebruiker.postcode.ToString();
            geslacht.Text = MainWindow.gebruiker.geslacht.ToString();
            straat.Text = MainWindow.gebruiker.straat.ToString();
            login.Text = MainWindow.gebruiker.gebruikersnaam.ToString();
            wachtwoord.Text = MainWindow.gebruiker.wachtwoord.ToString();
            bevestig.Text = MainWindow.gebruiker.wachtwoord.ToString();
            telefoon.Text = MainWindow.gebruiker.telefoon.ToString();
            gsm.Text = MainWindow.gebruiker.gsm.ToString();
            bedrijf.Text = MainWindow.gebruiker.bedrijf.ToString();
        }

        public void GegevensUpdaten()
        {
            MainWindow.gebruiker.naam = naam.Text;
            MainWindow.gebruiker.voornaam = voornaam.Text;
            MainWindow.gebruiker.geboortejaar = Convert.ToDateTime(geboorte.Text);
            MainWindow.gebruiker.postcode = Convert.ToInt32(postcode.Text);
            MainWindow.gebruiker.geslacht = Convert.ToChar(geslacht.Text);
            MainWindow.gebruiker.straat = straat.Text;
            MainWindow.gebruiker.gebruikersnaam = login.Text;
            MainWindow.gebruiker.wachtwoord = wachtwoord.Text;
            MainWindow.gebruiker.telefoon = telefoon.Text;
            MainWindow.gebruiker.gsm = gsm.Text;
            MainWindow.gebruiker.bedrijf = bedrijf.Text;
            
        }

        private void annuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
