using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Patient
    {
        //Getters and Setters 
        public int id { get; set; }
        public string beschrijving { get; set; }
        public string leeftijd { get; set; }
        public int categorie { get; set; }
        public string mantelzorgerleeftijd { get; set; }
        public string relatie { get; set; }
        public int hulpverlener { get; set; }
        public string overig { get; set; }

        //Constructors
        public Patient()
        {

        }
        public Patient(string beschrijving, string leeftijd, int categorie, string mantelzorgerleeftijd, string relatie, int hulpverlener, string overig)
        {
            this.beschrijving = beschrijving;
            this.leeftijd = leeftijd;
            this.categorie = categorie;
            this.mantelzorgerleeftijd = mantelzorgerleeftijd;
            this.relatie = relatie;
            this.hulpverlener = hulpverlener;
            this.overig = overig;
        }
    }
}
