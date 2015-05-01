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
    /// Interaction logic for AdminPaneel.xaml
    /// </summary>
    public partial class AdminPaneel : Window
    {
        private DAL dal = new DAL();
        public static Persoon persoon;

        public AdminPaneel()
        {
            InitializeComponent();
            try //Listbox gegevens ophalen
            {
                this.tabGebruikers.DataContext = dal.getPersonen();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MijnAccount mijnaccount = new MijnAccount();
            mijnaccount.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
        private void lstboxPersonen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            persoon = (Persoon)lstboxPersonen.SelectedItem;
            this.gb_info.DataContext = dal.getPersoon(persoon.Id);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                NieuweGebruiker nieuwegebruiker = new NieuweGebruiker();
                nieuwegebruiker.ShowDialog();
            }
            catch (Exception)
            {
                
            }
        }

        private void btnBewerk_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                BewerkGebruiker bewerkgebruiker = new BewerkGebruiker();
                bewerkgebruiker.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bent u zeker dat u "+persoon.voornaam+" "+persoon.naam+" wilt verwijderen?", "Persoon verwijderen",MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                dal.deletePersoon(persoon.Id);
                MessageBox.Show("Verwijderen gelukt!", "Gelukt!", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
