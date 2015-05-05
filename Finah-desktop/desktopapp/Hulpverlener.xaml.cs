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
    /// Interaction logic for hulpverlener.xaml
    /// </summary>
    public partial class hulpverlener : Window
    {
        DAL dal = new DAL();
        List<Overzicht> overzichten;
        List<Overzicht> overzichtenhulpverlener = new List<Overzicht>();
        public hulpverlener()
        {
            InitializeComponent();
            txtwelkom.Content = MainWindow.gebruiker.gebruikersnaam.ToString();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            try
            {
                overzichten = dal.getOverzicht();
                foreach (Overzicht o in overzichten)
                {
                    if (o.hulpverlenerID.Equals(MainWindow.gebruiker.Id))
                    {
                        overzichtenhulpverlener.Add(o);
                    }
                }
                this.dg_OverzichtOnderzoeker.DataContext = overzichtenhulpverlener;
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main=new MainWindow();
            main.Show();
            Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MijnAccount mijnaccount = new MijnAccount();
            mijnaccount.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Aanvraag aanvraag = new Aanvraag();
            aanvraag.ShowDialog();
        }
    }
}
