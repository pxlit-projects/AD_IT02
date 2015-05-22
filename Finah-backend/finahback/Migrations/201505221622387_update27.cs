namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update27 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Overzichts", "rapportID", c => c.String());
            DropColumn("dbo.Overzichts", "rapportID2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Overzichts", "rapportID2", c => c.Int(nullable: false));
            AlterColumn("dbo.Overzichts", "rapportID", c => c.Int(nullable: false));
        }
    }
}
