using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    public class Categorie
    {
        //Getters and Setters 
        public int id { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }

        //Constructors
        public Categorie()
        {

        }
        public Categorie(int id, string naam, string beschrijving)
        {
            this.id = id;
            this.naam = naam;
            this.beschrijving = beschrijving;
        }
    }
}
