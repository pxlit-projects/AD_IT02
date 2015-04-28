using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class Functie
    {
        //Getters and Setters 
        public int id { get; set; }
        [Required]
        public String functienaam { get; set; }
        public String beschrijving { get; set; }
    }
}