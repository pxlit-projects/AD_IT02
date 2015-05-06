using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    class VolledigOverzicht
    {
        //Getters and Setters 
        public int Id { get; set; }
        public int hulpverlenerID { get; set; }
        public int patientID { get; set; }
        public string patientbeschrijving { get; set; }
        public string patientleeftijd { get; set; }
        public int categorie { get; set; }
        public string mantelzorgerleeftijd { get; set; }
        public string relatie { get; set; }
        public DateTime tijdstip { get; set; }
        public int rapportID { get; set; }

        public VolledigOverzicht()
        {
        }
        public VolledigOverzicht(Patient p,Overzicht o)
        {
            this.Id = o.Id;
            this.hulpverlenerID = o.hulpverlenerID;
            this.patientID = o.patientID;
            this.patientbeschrijving = p.beschrijving;
            this.patientleeftijd = p.leeftijd;
            this.categorie = p.categorie;
            this.mantelzorgerleeftijd = p.mantelzorgerleeftijd;
            this.relatie = p.relatie;
            this.tijdstip = o.tijdstip;
            this.rapportID = o.rapportID;
        }
    }
}
