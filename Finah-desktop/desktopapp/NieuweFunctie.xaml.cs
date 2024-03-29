﻿using desktopapp.classes;
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
    /// Interaction logic for NieuweFunctie.xaml
    /// </summary>
    public partial class NieuweFunctie : Window
    {
        private DAL dal = new DAL();
        private Logger logger = new Logger();

        public NieuweFunctie()
        {
            InitializeComponent();
        }

        private async void btnBevestig_Click(object sender, RoutedEventArgs e)
        {
            try //gegevens opslaan in de database
            {
                Functie f = new Functie();

                // Naam testen
                if (txtfunctienaam.Text != "")
                {
                    f.functienaam = txtfunctienaam.Text;
                }
                else
                {
                    MessageBox.Show("Geef een functienaam");
                    txtfunctienaam.Focus();
                    return;
                }
                // Naam testen
                if (txtfunctiebeschrijving.Text != "")
                {
                    f.beschrijving = txtfunctiebeschrijving.Text;
                }
                else
                {
                    MessageBox.Show("Geef een functie beschrijving");
                    txtfunctiebeschrijving.Focus();
                    return;
                }
                
                await dal.insertFunctie(f);

                this.Close(); 
                MessageBox.Show("De nieuwe functie is opgeslagen!", "Nieuwe functie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                logger.log(ex.ToString());
            }
        }

        private void btnAnnuleer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
