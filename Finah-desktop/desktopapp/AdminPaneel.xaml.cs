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
            Persoon persoon = (Persoon)lstboxPersonen.SelectedItem;
            this.gb_info.DataContext = dal.getPersoon(persoon.Id);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                NieuweGebruiker nieuweGebruiker = new NieuweGebruiker();
                nieuweGebruiker.ShowDialog();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
