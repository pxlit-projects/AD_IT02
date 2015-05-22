using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class vragen
    {
        [Required]
        public int id { get; set; }
        public String vraag_thema { get; set; }
        public String vraag { get; set; }
            
       
    }
}