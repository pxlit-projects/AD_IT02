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
        public static Functie functie;

        public AdminPaneel()
        {
            InitializeComponent();
            try
            {
                this.tabFuncties.DataContext = dal.getFunctie();
                this.tabGebruikers.DataContext = dal.getPersonen();
                this.tabCategories.DataContext = dal.getCategorie();
            }
            catch (Exception)
            {
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
                NieuweFunctie nieuwegebruiker = new NieuweFunctie();
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

        private void cbo_functienaam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            functie = (Functie)cbo_functienaam.SelectedItem;
            this.lblbeschrijving.DataContext = dal.getFunctie(functie.id);
        }

        private void cbo_categorienaam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categorie categorie = (Categorie)cbo_categorienaam.SelectedItem;
            this.lblbeschrijvingCategorie.DataContext = dal.getCategorie(categorie.id);
        }

        private void btnNieuwFunctie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NieuweFunctie nieuweFunctie = new NieuweFunctie();
                nieuweFunctie.ShowDialog();
            }
            catch (Exception)
            {

            }

        }

        private void btnBewerkFunctie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BewerkFunctie bewerkfunctie = new BewerkFunctie();
                bewerkfunctie.ShowDialog();
            }
            catch (Exception)
            {

            }
        }
    }
}
