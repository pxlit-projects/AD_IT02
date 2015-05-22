using desktopapp.classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for NieuweGebruiker.xaml
    /// </summary>
    public partial class NieuweGebruiker : Window
    {
        private DAL dal = new DAL();
        private Logger logger = new Logger();

        public NieuweGebruiker()
        {
            InitializeComponent();
            try //combobox gegevens ophalen
            {
                this.cbo_Functie.DataContext = dal.getFunctie();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Persoon p = new Persoon();
                List<Persoon> personen = dal.getPersonen();

                // Voornaam testen
                if (txtvoornaam.Text != "")
                {
                    p.voornaam = txtvoornaam.Text;
                }
                else
                {
                    MessageBox.Show("Geef een voornaam in");
                    txtvoornaam.Focus();
                    return;
                }
                // Naam testen
                if (txtnaam.Text != "")
                {
                    p.naam = txtnaam.Text;
                }
                else
                {
                    MessageBox.Show("Geef een naam in");
                    txtnaam.Focus();
                    return;
                }
                // Geboortejaar testen
                DateTime dt;
                if (DateTime.TryParseExact(txtgeboorte.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out dt) == true)
                {
                    p.geboortejaar = Convert.ToDateTime(txtgeboorte.Text);
                }
                else
                {
                    MessageBox.Show("Geef een geboortejaar (dd/MM/yyyy) in");
                    txtgeboorte.Focus();
                    return;
                }
                // Straat testen
                if (txtstraat.Text != "")
                {
                    p.straat = txtstraat.Text;
                }
                else
                {
                    MessageBox.Show("Geef een straat in");
                    txtstraat.Focus();
                    return;
                }
                // Postcode testen
                if (txtpostcode.Text != "")
                {
                    p.postcode = Convert.ToInt32(txtpostcode.Text);
                }
                else
                {
                    MessageBox.Show("Geef een postcode in");
                    txtpostcode.Focus();
                    return;
                }
                // Telefoonnr testen
                if (txttelefoon.Text != "")
                {
                    p.telefoon = txttelefoon.Text;
                }
                else
                {
                    MessageBox.Show("Geef een telefoonnummer in");
                    txttelefoon.Focus();
                    return;
                }
                // Gsmnr testen
                if (txtgsm.Text != "")
                {
                    p.gsm = txtgsm.Text;
                }
                else
                {
                    MessageBox.Show("Geef een gsmnummer in");
                    txtgsm.Focus();
                    return;
                }
                // Functie testen
                if (cbo_Functie.SelectedItem != null)
                {
                    Functie functie = (Functie)cbo_Functie.SelectedItem;
                    p.functieID = functie.id;
                }
                else
                {
                    MessageBox.Show("Kies een functie");
                    return;
                }
                // Bedrijf testen
                if (txtbedrijf.Text != "")
                {
                    p.bedrijf = txtbedrijf.Text;
                }
                else
                {
                    MessageBox.Show("Geef een bedrijfsnaam in");
                    txtbedrijf.Focus();
                    return;
                }
                // Email testen
                if (Regex.IsMatch(txtemail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    p.email = txtemail.Text;
                }
                else
                {
                    MessageBox.Show("Geef een correct email adres in");
                    txtemail.Focus();
                    return;
                }
                // Geslacht testen
                if (txtgeslacht.Text != "")
                {
                    p.geslacht = txtgeslacht.Text;
                }
                else
                {
                    MessageBox.Show("Geef een geslacht in");
                    txtgeslacht.Focus();
                    return;
                }
                // Gebruikersnaam testen
                if (txtlogin.Text != "")
                {
                    foreach (Persoon per in personen)
                    {
                        if (per.gebruikersnaam == txtlogin.Text)
                        {
                            MessageBox.Show("Deze gebruikersnaam is al in gebruik");
                            txtlogin.Focus();
                            return;
                        }
                    }
                    p.gebruikersnaam = txtlogin.Text;
                }
                else
                {
                    MessageBox.Show("Geef een gebruikersnaam in");
                    txtlogin.Focus();
                    return;
                }
                // Wachtwoord testen
                if (txtwachtwoord.Text != "")
                {
                    p.wachtwoord = txtwachtwoord.Text;
                }
                else
                {
                    MessageBox.Show("Geef een wachtwoord in");
                    txtwachtwoord.Focus();
                    return;
                }

                p.geactiveerd = Convert.ToBoolean(cb_geactiveerd.IsChecked);

                await dal.insertPersoon(p);

                this.Close(); 
                MessageBox.Show("Gebruiker is opgeslagen!", "Nieuwe Gebruiker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
