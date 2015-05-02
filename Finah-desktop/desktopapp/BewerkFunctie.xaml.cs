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
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
