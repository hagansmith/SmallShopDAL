namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Variants", "ImageId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Variants", "ImageId", c => c.Long());
        }
    }
}
