using System.Data;

namespace finahback.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using finahback.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<finahback.Models.finahbackContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(finahback.Models.finahbackContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Persoons.AddOrUpdate(x => x.Id,
             new Persoon() { Id = 1, naam = "Satory", voornaam = "Glenn", functieID = 1, gebruikersnaam = "Satory", wachtwoord = "Test123"}
             );
            context.Functies.AddOrUpdate(x => x.id,
             new Functie() { id = 1, functienaam = "Admin", beschrijving = "Beheerder van het systeem."},
             new Functie() { id = 2, functienaam = "Onderzoeker", beschrijving = "Kan alle testen bekijken."},
             new Functie() { id = 3, functienaam = "Neuroloog", beschrijving = "Hulpverlener bij geval van hersenschade."}

             
             
             );
            context.Categories.AddOrUpdate(x=> x.id, new Categorie() {id = 1, naam = "hersenschade", beschrijving = "schade aan de hersenen"});


             
        }
    }
}
