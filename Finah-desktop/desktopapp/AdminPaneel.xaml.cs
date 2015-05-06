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
        private Persoon persoon;
        private Functie functie;
        private Categorie categorie;
        private Logger logger = new Logger();
        private int iPersonen = 0;
        private int iCategorie = 0;
        private int iFunctie = 0;

        public AdminPaneel()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            try
            {
                this.tabFuncties.DataContext = dal.getFunctie();
                this.tabGebruikers.DataContext = dal.getPersonen();
                this.tabCategories.DataContext = dal.getCategorie();

                this.lstboxPersonen.SelectedIndex = iPersonen;
                this.cbo_categorienaam.SelectedIndex = iCategorie;
                this.cbo_functienaam.SelectedIndex = iFunctie;
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MijnAccount mijnaccount = new MijnAccount();
                mijnaccount.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow main = new MainWindow();
                main.Show();
                Close();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }
        private void lstboxPersonen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                persoon = (Persoon)lstboxPersonen.SelectedItem;
                if (persoon != null)
                {
                    this.gb_info.DataContext = dal.getPersoon(persoon.Id);
                    iPersonen = lstboxPersonen.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                NieuweGebruiker nieuwegebruiker = new NieuweGebruiker();
                nieuwegebruiker.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnBewerk_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                BewerkGebruiker bewerkgebruiker = new BewerkGebruiker(persoon);
                bewerkgebruiker.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private async void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await dal.deletePersoon(persoon.Id);
                MessageBox.Show("Verwijderen gelukt!", "Gelukt!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void cbo_functienaam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                functie = (Functie)cbo_functienaam.SelectedItem;
                if (functie != null)
                {
                this.lblbeschrijving.DataContext = dal.getFunctie(functie.id);
                iFunctie = cbo_functienaam.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void cbo_categorienaam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                categorie = (Categorie)cbo_categorienaam.SelectedItem;
                if (categorie != null)
                {
                this.lblbeschrijvingCategorie.DataContext = dal.getCategorie(categorie.id);
                iCategorie = cbo_categorienaam.SelectedIndex;
                }
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnNieuwFunctie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NieuweFunctie nieuweFunctie = new NieuweFunctie();
                nieuweFunctie.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }

        }

        private void btnBewerkFunctie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BewerkFunctie bewerkfunctie = new BewerkFunctie(functie);
                bewerkfunctie.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private async void btnVerwijderFunctie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await dal.deleteFunctie(functie.id);
                MessageBox.Show("Verwijderen gelukt!", "Gelukt!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnNieuwCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NieuweCategorie nieuwecategorie = new NieuweCategorie();
                nieuwecategorie.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnBewerkCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BewerkCategorie bewerkcategorie = new BewerkCategorie(categorie);
                bewerkcategorie.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private async void btnVerwijderCategorie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await dal.deleteCategorie(categorie.id);
                MessageBox.Show("Verwijderen gelukt!", "Gelukt!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }
    }
}
