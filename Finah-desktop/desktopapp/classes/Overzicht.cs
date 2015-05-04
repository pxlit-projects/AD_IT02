using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    public class Overzicht
    {
        //Getters and Setters 
        public int Id { get; set; }
        public int hulpverlenerID { get; set; }
        public int patientID { get; set; }
        public DateTime tijdstip { get; set; }
        public int rapportID { get; set; }

        public Overzicht()
        {

        }
        public Overzicht(int hulpverlener, int patient, DateTime tijdstip)
        {
            this.hulpverlenerID = hulpverlener;
            this.patientID = patient;
            this.tijdstip = tijdstip;
        }
    }
}
