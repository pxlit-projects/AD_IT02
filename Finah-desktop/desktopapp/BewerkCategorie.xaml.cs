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
        DAL dal = new DAL();
        public BewerkCategorie()
        {
            InitializeComponent();
            try
            {
                txtcategorie.Text = AdminPaneel.categorie.naam;
                txtbeschrijving.Text = AdminPaneel.categorie.beschrijving;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPaneel.categorie.naam = txtcategorie.Text;
                AdminPaneel.categorie.beschrijving = txtbeschrijving.Text;

                DAL.UpdateCategorie(AdminPaneel.categorie);

                this.Close();
                MessageBox.Show("De categorie is opgeslagen!", "Nieuwe categorie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
