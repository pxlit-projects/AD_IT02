namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Persoons", "geslacht", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persoons", "geslacht");
        }
    }
}
