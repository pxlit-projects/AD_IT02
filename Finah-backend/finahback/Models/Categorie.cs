using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class Categorie
    {
        //Getters and Setters 
        public int id { get; set; }
        [Required]
        public string naam { get; set; }
        public string beschrijving { get; set; }
    }
}