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
    /// Interaction logic for BewerkGebruiker.xaml
    /// </summary>
    public partial class BewerkGebruiker : Window
    {
        private DAL dal = new DAL();
        private Logger logger = new Logger();
        private Persoon persoon = new Persoon();

        public BewerkGebruiker(Persoon p)
        {
            InitializeComponent();
            try //Gevens ophalen
            {
                this.cbo_Functie.DataContext = dal.getFunctie();
                persoon = p;
                txtvoornaam.Text = persoon.voornaam;
                txtnaam.Text = persoon.naam;
                txtgeboorte.Text = persoon.geboortejaar.ToString("dd-MM-yyyy");
                txtstraat.Text = persoon.straat;
                txtpostcode.Text = Convert.ToString(persoon.postcode);
                txttelefoon.Text = persoon.telefoon;
                txtgsm.Text = persoon.gsm;
                cbo_Functie.SelectedValue = persoon.functieID;
                txtbedrijf.Text = persoon.bedrijf;
                txtemail.Text = persoon.email;
                txtlogin.Text = persoon.gebruikersnaam;
                txtwachtwoord.Text = persoon.wachtwoord;
                cb_geactiveerd.IsChecked = persoon.geactiveerd;
                txtgeslacht.Text = persoon.geslacht;
            }
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                persoon.voornaam = txtvoornaam.Text;
                persoon.naam = txtnaam.Text;
                persoon.geboortejaar = Convert.ToDateTime(txtgeboorte.Text);
                persoon.straat = txtstraat.Text;
                persoon.postcode = Convert.ToInt32(txtpostcode.Text);
                persoon.telefoon = txttelefoon.Text;
                persoon.gsm = txtgsm.Text;
                Functie functie = (Functie)cbo_Functie.SelectedItem;
                persoon.functieID = functie.id;
                persoon.bedrijf = txtbedrijf.Text;
                persoon.email = txtemail.Text;
                persoon.gebruikersnaam = txtlogin.Text;
                persoon.wachtwoord = txtwachtwoord.Text;
                persoon.geslacht = txtgeslacht.Text;
                persoon.geactiveerd = Convert.ToBoolean(cb_geactiveerd.IsChecked);

                await dal.UpdateGebruiker(persoon);

                this.Close(); 
                MessageBox.Show("Gebruiker is opgeslagen!", "Nieuwe Gebruiker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.Message+"1","2");
            }
        }
    }
}
