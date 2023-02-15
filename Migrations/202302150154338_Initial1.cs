namespace SmartCardTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("public.Smartcards", "Partname0", c => c.String(maxLength: 13));
        }
        
        public override void Down()
        {
            AlterColumn("public.Smartcards", "Partname0", c => c.String(maxLength: 3));
        }
    }
}
