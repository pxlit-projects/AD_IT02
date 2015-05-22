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
        private Logger logger = new Logger();

        public Aanvraag()
        {
            InitializeComponent();

            try //combobox gegevens ophalen
            {
              this.cbo_Categorie.DataContext = dal.getCategorie();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private async void btnVerzendAanvraag_Click(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Patient p = new Patient();

                // Beschrijving testen
                if (txtBeschrijving.Text != "")
                {
                    p.beschrijving = txtBeschrijving.Text;
                }
                else
                {
                    MessageBox.Show("Geef een beschrijving");
                    txtBeschrijving.Focus();
                    return;
                }
                // Categorie testen
                if (cbo_Categorie.SelectedItem != null)
                {
                    Categorie cat = (Categorie)cbo_Categorie.SelectedItem;
                    p.categorie = cat.id;
                }
                else
                {
                    MessageBox.Show("Kies een categorie");
                    return;
                }
                // Relatie testen
                if (cbo_Relatie.SelectedItem != null)
                {
                    p.relatie = (string)((ComboBoxItem)cbo_Relatie.SelectedValue).Content;
                }
                else
                {
                    MessageBox.Show("Kies een relatie");
                    return;
                }

                p.overig = txtOverig.Text; //mag ook leeg zijn

                // leeftijd patient testen
                if (cbo_LeeftijdscatCLient.SelectedItem != null)
                {
                    p.leeftijd = (string)((ComboBoxItem)cbo_LeeftijdscatCLient.SelectedValue).Content;
                }
                else
                {
                    MessageBox.Show("Kies een leeftijd voor de patient");
                    return;
                }

                // leeftijd mantelzorger testen
                if (cbo_LeeftijdscatMantel.SelectedItem != null)
                {
                    p.mantelzorgerleeftijd = (string)((ComboBoxItem)cbo_LeeftijdscatMantel.SelectedItem).Content;
                }
                else
                {
                    MessageBox.Show("Kies een leeftijd voor de mantelzorger");
                    return;
                }

                p.hulpverlener = MainWindow.gebruiker.Id;

                await dal.insertPatient(p); //wachten tot de functie is uitgevoerd
                
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
                overzicht.rapportID = "P" + p.id;
                overzicht.rapportID2 = "M" + p.id;
                await dal.insertOverzicht(overzicht);

                AanvraagResult aanvraagresult = new AanvraagResult(p.id);
                this.Close();
                aanvraagresult.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnAnnuleerAanvraag_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}