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
    /// Interaction logic for BewerkFunctie.xaml
    /// </summary>
    public partial class BewerkFunctie : Window
    {
        DAL dal = new DAL();

        public BewerkFunctie()
        {
            InitializeComponent();
            try
            {
                txtfunctie.Text = AdminPaneel.functie.functienaam;
                txtbeschrijving.Text = AdminPaneel.functie.beschrijving;
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

        private void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AdminPaneel.functie.functienaam = txtfunctie.Text;
                AdminPaneel.functie.beschrijving = txtbeschrijving.Text;

                DAL.UpdateFunctie(AdminPaneel.functie);

                this.Close();
                MessageBox.Show("De functie is opgeslagen!", "Nieuwe functie", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
