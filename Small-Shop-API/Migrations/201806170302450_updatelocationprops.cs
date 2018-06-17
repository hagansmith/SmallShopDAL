namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatelocationprops : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "VariantId", c => c.Long(nullable: false));
            AlterColumn("dbo.Locations", "Available", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Available", c => c.String());
            AlterColumn("dbo.Locations", "VariantId", c => c.Int(nullable: false));
        }
    }
}
