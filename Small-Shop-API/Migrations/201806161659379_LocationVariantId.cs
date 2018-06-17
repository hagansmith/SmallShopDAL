namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LocationVariantId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "VariantId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "VariantId");
        }
    }
}
