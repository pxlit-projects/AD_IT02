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
using System.Diagnostics;
using System.Windows.Navigation;

namespace desktopapp
{
    /// <summary>
    /// Interaction logic for AanvraagResult.xaml
    /// </summary>
    public partial class AanvraagResult : Window
    {
        private string pUrl, mUrl;
        private string url;

        public AanvraagResult(int id)
        {
            InitializeComponent();
            url = "http://adit02.cloudapp.net/index.php?id=";
            pUrl = url + "P" + id;
            mUrl = url + "M" + id;
            patient.DataContext = pUrl;
            mantelzorger.DataContext = mUrl;
        }
        private void Hyperlink_RequestNavigate_Patient(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(pUrl));
            e.Handled = true;
        }
        private void Hyperlink_RequestNavigate_Mantelzorger(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(mUrl));
            e.Handled = true;
        }

        private void kopieerPatient_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(patient.Text);
        }

        private void kopieerMantelzorg_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(mantelzorger.Text);
        }

        private void sluit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
