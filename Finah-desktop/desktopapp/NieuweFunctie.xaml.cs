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
    /// Interaction logic for NieuweFunctie.xaml
    /// </summary>
    public partial class NieuweFunctie : Window
    {
        DAL dal = new DAL();
        public NieuweFunctie()
        {
            InitializeComponent();
        }

        private void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Functie f = new Functie();

                f.functienaam = txtfunctienaam.Text;
                f.beschrijving = txtfunctiebeschrijving.Text;

                dal.insertFunctie(f);

                this.Close();
                MessageBox.Show("De nieuwe functie is opgeslagen!", "Nieuwe functie", MessageBoxButton.OK, MessageBoxImage.Information);
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
