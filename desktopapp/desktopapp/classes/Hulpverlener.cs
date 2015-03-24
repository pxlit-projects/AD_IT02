using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Hulpverlener
    {
        private int hulpverlenerID;
        private String naam;
        private String voornaam;
        private DateTime geboortejaar;
        private char geslacht;
        private String straat;
        private Gemeente postcode;
        private String telefoon;
        private String gsm;
        private Functie functie;
        private String bedrijf;
        private String email;

        public Hulpverlener(int id, String naam, String voornaam)
        {
            this.hulpverlenerID = id;
            this.naam = naam;
            this.voornaam = voornaam;
        }
        
        public int HulpverlenerID
        {
            get { return hulpverlenerID; }
            set { hulpverlenerID = value; }
        }

        public String Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public String Voornaam
        {
            get { return voornaam; }
            set { voornaam = value; }
        }

        public DateTime Geboortejaar
        {
            get { return geboortejaar; }
            set { geboortejaar = value; }
        }
        
        public char Geslacht
        {
            get { return geslacht; }
            set { geslacht = value; }
        }

        public String Straat
        {
            get { return straat; }
            set { straat = value; }
        }

        public String Telefoon
        {
            get { return telefoon; }
            set { telefoon = value; }
        }

        public String Gsm
        {
            get { return gsm; }
            set { gsm = value; }
        }
        
        public String Bedrijf
        {
            get { return bedrijf; }
            set { bedrijf = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }


    }
}
