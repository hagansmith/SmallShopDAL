namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Reorders",
                    c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        variantId = c.Long(nullable: false),
                        quantity = c.Int(nullable: false),
                        orderDate = c.DateTime(nullable: false),
                        dateReceived = c.DateTime(nullable: false),
                        quantityRecieved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Variants", t => t.variantId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Reorders");
        }
    }
}
