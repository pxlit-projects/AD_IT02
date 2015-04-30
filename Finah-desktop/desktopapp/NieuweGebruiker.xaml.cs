using desktopapp.classes;
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

namespace desktopapp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NieuweGebruiker : Window
    {
        private DAL dal = new DAL();

        public NieuweGebruiker()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Persoon p = new Persoon();

                p.voornaam = txtvoornaam.Text;
                p.naam = txtnaam.Text;
                //p.geboortejaar = txtgeboorte.Text;
                p.straat = txtstraat.Text;
                //p.postcode = txtstraat.Text;
                p.telefoon = txttelefoon.Text;
                p.gsm = txtgsm.Text;
                //p.functieID = txtfunctie.Text;
                p.bedrijf = txtbedrijf.Text;
                p.email = txtemail.Text;
                p.gebruikersnaam = txtlogin.Text;
                p.wachtwoord = txtwachtwoord.Text;
                p.geslacht = txtgeslacht.Text;
                //p.geactiveerd = txtgeactiveerd.Text;

                dal.insertPersoon(p);
                this.Close();
                MessageBox.Show("Gebruiker is opgeslagen!", "Nieuwe Gebruiker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
