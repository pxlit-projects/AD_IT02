namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update26 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.vragens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        vraag_thema = c.String(),
                        vraag = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.vragens");
        }
    }
}
