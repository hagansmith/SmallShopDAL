namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVariantPropertiesForStock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Variants", "MinimumStock", c => c.Int(nullable: false));
            AddColumn("dbo.Variants", "AllocatedStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Variants", "AllocatedStock");
            DropColumn("dbo.Variants", "MinimumStock");
        }
    }
}
