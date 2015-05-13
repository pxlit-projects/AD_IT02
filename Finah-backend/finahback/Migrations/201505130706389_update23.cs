namespace finahback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vraags",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rapportId = c.Int(nullable: false),
                        vraag1 = c.Int(nullable: false),
                        vraag2 = c.Int(nullable: false),
                        vraag3 = c.Int(nullable: false),
                        vraag4 = c.Int(nullable: false),
                        vraag5 = c.Int(nullable: false),
                        vraag6 = c.Int(nullable: false),
                        vraag7 = c.Int(nullable: false),
                        vraag8 = c.Int(nullable: false),
                        vraag9 = c.Int(nullable: false),
                        vraag10 = c.Int(nullable: false),
                        vraag11 = c.Int(nullable: false),
                        vraag12 = c.Int(nullable: false),
                        vraag13 = c.Int(nullable: false),
                        vraag14 = c.Int(nullable: false),
                        vraag15 = c.Int(nullable: false),
                        vraag16 = c.Int(nullable: false),
                        vraag17 = c.Int(nullable: false),
                        vraag18 = c.Int(nullable: false),
                        vraag19 = c.Int(nullable: false),
                        vraag20 = c.Int(nullable: false),
                        vraag21 = c.Int(nullable: false),
                        vraag22 = c.Int(nullable: false),
                        vraag23 = c.Int(nullable: false),
                        vraag24 = c.Int(nullable: false),
                        vraag25 = c.Int(nullable: false),
                        vraag26 = c.Int(nullable: false),
                        vraag27 = c.Int(nullable: false),
                        vraag28 = c.Int(nullable: false),
                        vraag29 = c.Int(nullable: false),
                        vraag30 = c.Int(nullable: false),
                        vraag31 = c.Int(nullable: false),
                        vraag32 = c.Int(nullable: false),
                        vraag33 = c.Int(nullable: false),
                        vraag34 = c.Int(nullable: false),
                        vraag35 = c.Int(nullable: false),
                        vraag36 = c.Int(nullable: false),
                        vraag37 = c.Int(nullable: false),
                        vraag38 = c.Int(nullable: false),
                        vraag39 = c.Int(nullable: false),
                        vraag40 = c.Int(nullable: false),
                        vraag41 = c.Int(nullable: false),
                        vraag42 = c.Int(nullable: false),
                        vraag43 = c.Int(nullable: false),
                        vraag44 = c.Int(nullable: false),
                        vraag45 = c.Int(nullable: false),
                        vraag46 = c.Int(nullable: false),
                        vraag47 = c.Int(nullable: false),
                        vraag48 = c.Int(nullable: false),
                        vraag49 = c.Int(nullable: false),
                        vraag50 = c.Int(nullable: false),
                        vraag51 = c.Int(nullable: false),
                        vraag52 = c.Int(nullable: false),
                        vraag53 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vraags");
        }
    }
}
