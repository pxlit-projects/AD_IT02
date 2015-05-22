using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class Overzicht
    {
        //Getters and Setters 
        [Key]
        public int Id { get; set; }
        [Required]
        public int hulpverlenerID { get; set; }
        public int PatientID { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime tijdstip { get; set; }
        public String rapportID { get; set; }
        public String rapportID2 { get; set; }
        
       
        // Navigation property
        public Overzicht()
        {
            
        }
    }
}