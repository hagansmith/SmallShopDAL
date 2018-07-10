namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class activestatusonvariant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Variants", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Variants", "Active");
        }
    }
}
