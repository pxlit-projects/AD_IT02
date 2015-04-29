using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class Persoon
    {
        //Getters and Setters 
        [Key]
        public int Id { get; set; }
        [Required]
        public String naam { get; set; }
        public String voornaam { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime geboortejaar { get; set; }
        public String geslacht { get; set; }
        public String straat { get; set; }
        public int postcode { get; set; }
        public String telefoon { get; set; }
        public String gsm { get; set; }
        public int functieID{get; set; }
        public String bedrijf { get; set; }
        public String email { get; set; }
        public String gebruikersnaam { get; set; }
        public String wachtwoord { get; set; }
        public Boolean geactiveerd { get; set; }

       
        // Navigation property
        public Persoon(String Gebruikersnaam,String Wachtwoord)
        {
            this.gebruikersnaam = Gebruikersnaam;
            this.wachtwoord = Wachtwoord;
        }

        public Persoon()
        {
            
        }
        
        
       
    }
}