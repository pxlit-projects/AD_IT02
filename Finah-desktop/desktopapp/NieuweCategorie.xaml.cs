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
    /// Interaction logic for NieuweCategorie.xaml
    /// </summary>
    public partial class NieuweCategorie : Window
    {
        private DAL dal = new DAL();
        private Logger logger = new Logger();

        public NieuweCategorie()
        {
            InitializeComponent();
        }

        private async void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Categorie cat = new Categorie();

                cat.naam = txtcategorienaam.Text;
                cat.beschrijving = txtcategoriebeschrijving.Text;

                await dal.insertCategorie(cat);

                this.Close(); 
                MessageBox.Show("De nieuwe categorie is opgeslagen!", "Nieuwe functie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
