namespace VirtualGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedImageTypeInPersonTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Image", c => c.String());
        }
    }
}
