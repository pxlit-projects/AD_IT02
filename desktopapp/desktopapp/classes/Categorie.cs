using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Categorie
    {
        private String naam;
        private String beschrijving;

        public Categorie(String naam, String beschrijving)
        {
            this.naam = naam;
            this.beschrijving = beschrijving;
        }
        
        public String Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public String Naam
        {
            get { return naam; }
            set { naam = value; }
        }

    }
}
