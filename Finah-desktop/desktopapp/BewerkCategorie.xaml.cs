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
    /// Interaction logic for BewerkCategorie.xaml
    /// </summary>
    public partial class BewerkCategorie : Window
    {
        private Categorie categorie = new Categorie();
        private DAL dal = new DAL();
        private Logger logger = new Logger();

        public BewerkCategorie(Categorie c)
        {
            InitializeComponent();
            try
            {
                categorie = c;
                txtcategorie.Text = categorie.naam;
                txtbeschrijving.Text = categorie.beschrijving;
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private async void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                categorie.naam = txtcategorie.Text;
                categorie.beschrijving = txtbeschrijving.Text;

                await dal.UpdateCategorie(categorie);

                this.Close(); 
                MessageBox.Show("De categorie is opgeslagen!", "Nieuwe categorie", MessageBoxButton.OK, MessageBoxImage.Information);
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
