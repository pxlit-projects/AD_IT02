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
        public int id { get; set; }
        public string functienaam { get; set; }
        public string beschrijving { get; set; }

        //Constructors
        public Functie(int id, string functienaam, string beschrijving)
        {
            this.id = id;
            this.functienaam = functienaam;
            this.beschrijving = beschrijving;
        }
    }
}
