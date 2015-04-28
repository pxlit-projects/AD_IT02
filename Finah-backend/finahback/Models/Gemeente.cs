using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class Gemeente
    {
         //Getters and Setters
        public int id { get; set; }
        [Required]
        private String postcode{ set; get;}
        private String gemeente { set; get; }
    
    }
}