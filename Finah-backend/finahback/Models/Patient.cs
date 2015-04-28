using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class Patient
    {
        //Getters and Setters 
        public int id { get; set; }
        [Required]
        public string beschrijving { get; set; }
        public string leeftijd { get; set; }
        public int categorie { get; set; }
        public string mantelzorgerleeftijd { get; set; }
        public string relatie { get; set; }
        public int hulpverlener { get; set; }
        public string overig { get; set; }
    }
}