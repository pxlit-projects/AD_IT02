namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Overzichts", "rapportID2", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Overzichts", "rapportID2");
        }
    }
}
