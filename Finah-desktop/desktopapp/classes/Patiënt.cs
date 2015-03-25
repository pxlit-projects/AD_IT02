using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class Patiënt
    {
        private int patiëntID;
        private String beschrijving;
        private String leeftijdsCategorie;
        private Categorie categorie;
        private Mantelzorger mantelzorger;
        public String relatie;

        public String Relatie
        {
            get { return relatie; }
            set { relatie = value; }
        }

        public Mantelzorger Mantelzorger
        {
            get { return mantelzorger; }
            set { mantelzorger = value; }
        }

        public String LeeftijdsCategorie
        {
            get { return leeftijdsCategorie; }
            set { leeftijdsCategorie = value; }
        }

        public String Beschrijving
        {
            get { return beschrijving; }
            set { beschrijving = value; }
        }

        public int PatiëntID
        {
            get { return patiëntID; }
            set { patiëntID = value; }
        }
 
    }
}
