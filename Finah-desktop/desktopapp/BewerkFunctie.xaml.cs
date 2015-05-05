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
        private DAL dal = new DAL();
        private Functie functie = new Functie();
        private Logger logger = new Logger();

        public BewerkFunctie(Functie f)
        {
            InitializeComponent();
            try
            {
                functie = f;
                txtfunctie.Text = functie.functienaam;
                txtbeschrijving.Text = functie.beschrijving;
            }
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                functie.functienaam = txtfunctie.Text;
                functie.beschrijving = txtbeschrijving.Text;

                await dal.UpdateFunctie(functie);

                this.Close(); 
                MessageBox.Show("De functie is opgeslagen!", "Nieuwe functie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.Message);
            }
        }
    }
}
