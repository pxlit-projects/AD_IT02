using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace finahback.Models
{
    public class finahbackContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public finahbackContext() : base("name=finahbackContext")
        {
        }

        public System.Data.Entity.DbSet<finahback.Models.Persoon> Persoons { get; set; }
        public object Personen { get; set; }
        public System.Data.Entity.DbSet<finahback.Models.Functie> Functies  {get; set; }
        public object functies { get; set; }

        public System.Data.Entity.DbSet<finahback.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<finahback.Models.Categorie> Categories { get; set; }

        public System.Data.Entity.DbSet<finahback.Models.Overzicht> Overzichts { get; set; }

        public System.Data.Entity.DbSet<finahback.Models.Vraag> Vraags { get; set; }
    }
}
