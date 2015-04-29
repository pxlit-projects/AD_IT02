using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktopapp.classes
{
    public class Persoon
    {
        //Getters and Setters 
        public int Id { get; set; }
        public String naam { get; set; }
        public String voornaam { get; set; }
        public DateTime geboortejaar { get; set; }
        public String geslacht { get; set; }
        public String straat { get; set; }
        public int postcode { get; set; }
        public String telefoon { get; set; }
        public String gsm { get; set; }
        public int functieID { get; set; }
        public String bedrijf { get; set; }
        public String email { get; set; }
        public String gebruikersnaam { get; set; }
        public String wachtwoord { get; set; }
        public Boolean geactiveerd { get; set; }

        //Constructors
        public Persoon()
        {

        }
       
    }
}
