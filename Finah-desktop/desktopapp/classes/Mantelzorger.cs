using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Mantelzorger
    {
        private int mantelzorgerID;
        private String leeftijdsCategorie;
        private String beschrijving;
        private Patiënt patient;
        private String relatie;

        public String Relatie
        {
            get { return relatie; }
            set { relatie = value; }
        } 
        
        public Patiënt Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public Mantelzorger(int id, String leeftijd, String beschrijving)
        {
            this.mantelzorgerID = id;
            this.leeftijdsCategorie = leeftijd;
            this.beschrijving = beschrijving;
        }
        
        public String Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public String LeeftijdsCategorie
        {
            get { return leeftijdsCategorie; }
            set { leeftijdsCategorie = value; }
        }

        public int MantelzorgerID
        {
            get { return mantelzorgerID; }
            set { mantelzorgerID = value; }
        }


    }
}
