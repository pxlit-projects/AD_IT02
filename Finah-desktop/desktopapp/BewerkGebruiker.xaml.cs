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
        public DAL dal = new DAL();
        public BewerkGebruiker()
        {
            InitializeComponent();
            try //combobox gegevens ophalen
            {
                this.cbo_Functie.DataContext = dal.getFunctie();

                txtvoornaam.Text = AdminPaneel.persoon.voornaam;
                txtnaam.Text = AdminPaneel.persoon.naam;
                txtgeboorte.Text = Convert.ToString(AdminPaneel.persoon.geboortejaar);
                txtstraat.Text = AdminPaneel.persoon.straat;
                txtpostcode.Text = Convert.ToString(AdminPaneel.persoon.postcode);
                txttelefoon.Text = AdminPaneel.persoon.telefoon;
                txtgsm.Text = AdminPaneel.persoon.gsm;
                cbo_Functie.SelectedValue = AdminPaneel.persoon.functieID;//MOET NOG TEGOEI GEMAAKT WORDEN
                txtbedrijf.Text = AdminPaneel.persoon.bedrijf;
                txtemail.Text = AdminPaneel.persoon.email;
                txtlogin.Text = AdminPaneel.persoon.gebruikersnaam;
                txtwachtwoord.Text = AdminPaneel.persoon.wachtwoord;
                cb_geactiveerd.IsChecked = AdminPaneel.persoon.geactiveerd;
                txtgeslacht.Text = AdminPaneel.persoon.geslacht;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                AdminPaneel.persoon.voornaam = txtvoornaam.Text;
                AdminPaneel.persoon.naam = txtnaam.Text;
                AdminPaneel.persoon.geboortejaar = Convert.ToDateTime(txtgeboorte.Text);
                AdminPaneel.persoon.straat = txtstraat.Text;
                AdminPaneel.persoon.postcode = Convert.ToInt32(txtpostcode.Text);
                AdminPaneel.persoon.telefoon = txttelefoon.Text;
                AdminPaneel.persoon.gsm = txtgsm.Text;
                Functie functie = (Functie)cbo_Functie.SelectedItem;
                AdminPaneel.persoon.functieID = functie.id;
                AdminPaneel.persoon.bedrijf = txtbedrijf.Text;
                AdminPaneel.persoon.email = txtemail.Text;
                AdminPaneel.persoon.gebruikersnaam = txtlogin.Text;
                AdminPaneel.persoon.wachtwoord = txtwachtwoord.Text;
                AdminPaneel.persoon.geslacht = txtgeslacht.Text;
                AdminPaneel.persoon.geactiveerd = Convert.ToBoolean(cb_geactiveerd.IsChecked);

                DAL.UpdateGebruiker(AdminPaneel.persoon);

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
