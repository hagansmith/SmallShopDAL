namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LineItems", "VariantId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LineItems", "VariantId", c => c.String());
        }
    }
}
