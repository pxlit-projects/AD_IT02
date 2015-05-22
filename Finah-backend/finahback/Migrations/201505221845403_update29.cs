namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Overzichts", "rapportID2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Overzichts", "rapportID2");
        }
    }
}
