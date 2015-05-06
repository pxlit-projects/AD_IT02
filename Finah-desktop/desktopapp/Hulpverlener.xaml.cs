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
        private DAL dal = new DAL();
        private List<Overzicht> overzichten;
        private List<Patient> patienten;
        private List<VolledigOverzicht> volledigoverzicht;
        private List<Overzicht> overzichtenhulpverlener = new List<Overzicht>();
        private List<Patient> overzichtenpatient = new List<Patient>();
        private Logger logger = new Logger();
        private VolledigOverzicht v;

        public hulpverlener()
        {
            InitializeComponent();
            txtwelkom.Content = "Welkom " + MainWindow.gebruiker.voornaam.ToString() + " " + MainWindow.gebruiker.naam.ToString();
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            try
            {
                volledigoverzicht = new List<VolledigOverzicht>();
                overzichten = dal.getOverzicht();
                patienten = dal.getPatienten();

                foreach (Overzicht o in overzichten)
                {
                    if (o.hulpverlenerID.Equals(MainWindow.gebruiker.Id))
                    {
                        foreach (Patient p in patienten)
                        {
                            if (o.patientID == p.id)
                            {
                                if (o != null & p != null)
                                {
                                    v = new VolledigOverzicht(p, o);
                                    volledigoverzicht.Add(v);
                                } 
                            }
                        }
                    }
                }
                this.dg_OverzichtHulpverlener.DataContext = volledigoverzicht;

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
                MainWindow main = new MainWindow();
                main.Show();
                Close();
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
                MijnAccount mijnaccount = new MijnAccount();
                mijnaccount.ShowDialog();
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
                Aanvraag aanvraag = new Aanvraag();
                aanvraag.ShowDialog();
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }
    }
}
