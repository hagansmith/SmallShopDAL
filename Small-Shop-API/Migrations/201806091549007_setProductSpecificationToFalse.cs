namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setProductSpecificationToFalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Options", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Variants");
            AlterColumn("dbo.Products", "Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Variants", "Id", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Variants", "Id");
            AddForeignKey("dbo.Images", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Options", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Variants", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Options", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Products");
            DropPrimaryKey("dbo.Variants");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Variants", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Variants", "Id");
            AddPrimaryKey("dbo.Products", "Id");
            AddForeignKey("dbo.Variants", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Options", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Images", "Product_Id", "dbo.Products", "Id");
        }
    }
}
