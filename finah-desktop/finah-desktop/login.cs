using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finah_desktop
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void logbutton_Click(object sender, EventArgs e)
        {
            DBconnect db = new DBconnect();
           db.OpenConnection();
          List <String>[] result = db.Select(gebruiker.Text,wachtwoord.Text);
            if (result[1].ToString() == gebruiker.Text && result[2].ToString() == wachtwoord.Text)
            {
                overzichtHulp overzicht = new overzichtHulp();
                overzicht.Show();
                Hide();

            }
            else
            {
                MessageBox.Show("Verkeerde Gevens");
                overzichtHulp overzicht = new overzichtHulp();
                overzicht.Show();
                Hide();
            }

        }

        
    }

   
}
