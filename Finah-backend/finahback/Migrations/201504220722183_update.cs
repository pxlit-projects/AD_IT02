namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Persoons", "functie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persoons", "functie", c => c.Int(nullable: false));
        }
    }
}
