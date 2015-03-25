using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    public class Functie
    {
        //Getters and Setters 
        public String functienaam { get; set; }
        public String beschrijving { get; set; }

        //Constructors
        public Functie(String functienaam, String beschrijving)
        {
            this.functienaam = functienaam;
            this.beschrijving = beschrijving;
        }
    }
}
