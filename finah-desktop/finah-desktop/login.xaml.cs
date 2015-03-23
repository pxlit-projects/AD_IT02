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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web.Security;

namespace finah_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {

                if (Membership.GetUser("admin2") == null)
                {
                    Membership.CreateUser("admin2", "Pass!2");

                }



                if (!Roles.RoleExists("Administrator"))
                    Roles.CreateRole("Administrator");
                if (!Roles.RoleExists("User"))
                    Roles.CreateRole("User");
                if (!Roles.IsUserInRole("admin2", "Administrator"))
                    Roles.AddUserToRole("admin2", "Administrator");
            }
            catch (MemberAccessException ex)
            {
                Console.WriteLine(ex);
            }

        }
    }

}

