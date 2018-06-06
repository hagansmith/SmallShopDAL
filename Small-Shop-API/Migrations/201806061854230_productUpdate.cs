namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropIndex("dbo.Images", new[] { "ProductId" });
            AddColumn("dbo.Images", "Product_Id", c => c.Long());
            AddColumn("dbo.Products", "Image_Id", c => c.Long());
            AddColumn("dbo.Variants", "Option2", c => c.String());
            AddColumn("dbo.Variants", "Option3", c => c.String());
            AlterColumn("dbo.Products", "PublishedAt", c => c.DateTime());
            AlterColumn("dbo.Variants", "Grams", c => c.Int(nullable: false));
            AlterColumn("dbo.Variants", "ImageId", c => c.Int());
            AlterColumn("dbo.Variants", "Weight", c => c.Single(nullable: false));
            AlterColumn("dbo.Variants", "InventoryItemId", c => c.Long(nullable: false));
            CreateIndex("dbo.Images", "Product_Id");
            CreateIndex("dbo.Products", "Image_Id");
            AddForeignKey("dbo.Products", "Image_Id", "dbo.Images", "Id");
            AddForeignKey("dbo.Images", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Products", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image", c => c.String());
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Image_Id", "dbo.Images");
            DropIndex("dbo.Products", new[] { "Image_Id" });
            DropIndex("dbo.Images", new[] { "Product_Id" });
            AlterColumn("dbo.Variants", "InventoryItemId", c => c.String());
            AlterColumn("dbo.Variants", "Weight", c => c.Int(nullable: false));
            AlterColumn("dbo.Variants", "ImageId", c => c.Int(nullable: false));
            AlterColumn("dbo.Variants", "Grams", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "PublishedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Variants", "Option3");
            DropColumn("dbo.Variants", "Option2");
            DropColumn("dbo.Products", "Image_Id");
            DropColumn("dbo.Images", "Product_Id");
            CreateIndex("dbo.Images", "ProductId");
            AddForeignKey("dbo.Images", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
