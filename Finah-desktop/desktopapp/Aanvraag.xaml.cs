using desktopapp.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Interaction logic for Aanvraag.xaml
    /// </summary>
    public partial class Aanvraag : Window
    {
        private DAL dal = new DAL();

        public Aanvraag()
        {
            InitializeComponent();

            try //combobox gegevens ophalen
            {
              this.cbo_Categorie.DataContext = dal.getCategorie();
            }
            catch (Exception)
            {  
                throw;
            }
        }

        private async void btnVerzendAanvraag_Click(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Patient p = new Patient();

                p.beschrijving = txtBeschrijving.Text;
                Categorie cat = (Categorie)cbo_Categorie.SelectedItem;
                p.categorie = cat.id;
                p.relatie = (string)((ComboBoxItem)cbo_Relatie.SelectedValue).Content;
                p.overig = txtOverig.Text;
                p.leeftijd = (string)((ComboBoxItem)cbo_LeeftijdscatCLient.SelectedValue).Content;
                p.mantelzorgerleeftijd = (string)((ComboBoxItem)cbo_LeeftijdscatMantel.SelectedItem).Content;
                p.hulpverlener = MainWindow.gebruiker.Id;

                await dal.insertPatient(p);
                

                List<Patient> patienten = dal.getPatienten();
                foreach (Patient patient in patienten)
                {
                    if (patient.beschrijving.Equals(p.beschrijving))
                    {
                        p.id = patient.id;
                    }
                }

                Overzicht overzicht = new Overzicht();
                overzicht.hulpverlenerID = MainWindow.gebruiker.Id;
                overzicht.patientID = p.id;
                overzicht.tijdstip = DateTime.Now;
                dal.insertOverzicht(overzicht);

                this.Close();
                MessageBox.Show("Aanvraag is opgeslagen!", "Aanvraag", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAnnuleerAanvraag_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}