namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Variants", "ImageId", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Variants", "ImageId", c => c.Int());
        }
    }
}
