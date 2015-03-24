using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Functie
    {
        private String functienaam;
        private String beschrijving;

        public Functie(String functienaam, String beschrijving)
        {
            this.functienaam = functienaam;
            this.beschrijving = beschrijving;

        }
        
        public String Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public String Functienaam
        {
            get { return functienaam; }
            set { functienaam = value; }
        }


    }
}
