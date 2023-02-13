namespace SmartCardTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 20),
                        HashPassword = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Smartcards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Partnumber = c.String(nullable: false, maxLength: 20),
                        Partname1 = c.String(maxLength: 8),
                        Partname2 = c.String(maxLength: 8),
                        Partname3 = c.String(maxLength: 8),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("public.Smartcards");
            DropTable("public.Accounts");
        }
    }
}
