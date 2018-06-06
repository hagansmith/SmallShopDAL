namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdFeild : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LineItems");
            AlterColumn("dbo.LineItems", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.LineItems", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LineItems");
            AlterColumn("dbo.LineItems", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.LineItems", "Id");
        }
    }
}
