namespace VirtualGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedImageTypeInPersonTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Image");
        }
    }
}
