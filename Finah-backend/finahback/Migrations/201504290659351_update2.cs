namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        beschrijving = c.String(nullable: false),
                        leeftijd = c.String(),
                        categorie = c.Int(nullable: false),
                        mantelzorgerleeftijd = c.String(),
                        relatie = c.String(),
                        hulpverlener = c.Int(nullable: false),
                        overig = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
