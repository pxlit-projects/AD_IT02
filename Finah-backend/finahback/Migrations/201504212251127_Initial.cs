namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Functies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        functienaam = c.String(nullable: false),
                        beschrijving = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Persoons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        naam = c.String(nullable: false),
                        voornaam = c.String(),
                        geboortejaar = c.DateTime(nullable: false),
                        straat = c.String(),
                        postcode = c.Int(nullable: false),
                        telefoon = c.String(),
                        gsm = c.String(),
                        functieID = c.Int(nullable: false),
                        bedrijf = c.String(),
                        email = c.String(),
                        gebruikersnaam = c.String(),
                        wachtwoord = c.String(),
                        geactiveerd = c.Boolean(nullable: false),
                        functie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persoons");
            DropTable("dbo.Functies");
        }
    }
}
