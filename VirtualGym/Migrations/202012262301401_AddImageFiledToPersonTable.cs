namespace VirtualGym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageFiledToPersonTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Image");
        }
    }
}
