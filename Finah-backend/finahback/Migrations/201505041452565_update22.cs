namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Overzichts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        hulpverlenerID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                        tijdstip = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        rapportID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Overzichts");
        }
    }
}
