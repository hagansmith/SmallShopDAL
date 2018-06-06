namespace Small_Shop_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        Address1 = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        LastName = c.String(),
                        Address2 = c.String(),
                        Company = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Name = c.String(),
                        CountryCode = c.String(),
                        ProvinceCode = c.String(),
                        CustomerId = c.Long(),
                        CountryName = c.String(),
                        Default = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        AcceptsMarketing = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        OrdersCount = c.Long(nullable: false),
                        State = c.String(),
                        TotalSpent = c.String(),
                        LastOrderId = c.String(),
                        Note = c.String(),
                        VerifiedEmail = c.Boolean(nullable: false),
                        MultipassIdentifier = c.String(),
                        TaxExempt = c.Boolean(nullable: false),
                        Phone = c.String(),
                        Tags = c.String(),
                        LastOrderName = c.String(),
                        DefaultAddress_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.DefaultAddress_Id)
                .Index(t => t.DefaultAddress_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Position = c.Long(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Alt = c.String(),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Src = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VariantId = c.String(),
                        Title = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.String(),
                        Sku = c.String(),
                        VariantTitle = c.String(),
                        Vendor = c.String(),
                        FulfillmentService = c.String(),
                        ProductId = c.Long(nullable: false),
                        RequiresShipping = c.Boolean(nullable: false),
                        Taxable = c.Boolean(nullable: false),
                        GiftCard = c.Boolean(nullable: false),
                        Name = c.String(),
                        VariantInventoryManagement = c.String(),
                        ProductExists = c.Boolean(nullable: false),
                        FulfillableQuantity = c.Int(nullable: false),
                        Grams = c.Int(nullable: false),
                        TotalDiscount = c.String(),
                        Order_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Name = c.String(),
                        Position = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        ClosedAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Number = c.Long(nullable: false),
                        Note = c.String(),
                        Token = c.String(),
                        Gateway = c.String(),
                        Test = c.Boolean(nullable: false),
                        TotalPrice = c.String(),
                        SubtotalPrice = c.String(),
                        TotalWeight = c.Int(nullable: false),
                        TotalTax = c.String(),
                        TaxesIncluded = c.Boolean(nullable: false),
                        Currency = c.String(),
                        FinancialStatus = c.String(),
                        Confirmed = c.Boolean(nullable: false),
                        TotalDiscounts = c.String(),
                        TotalLineItemsPrice = c.String(),
                        CartToken = c.Long(nullable: false),
                        BuyerAcceptsMarketing = c.Boolean(nullable: false),
                        Name = c.String(),
                        LandingSite = c.String(),
                        CancelledAt = c.DateTime(nullable: false),
                        CancelReason = c.String(),
                        TotalPriceUsd = c.String(),
                        CheckoutToken = c.String(),
                        Reference = c.String(),
                        UserId = c.Long(nullable: false),
                        LocationId = c.String(),
                        SourceIdentifier = c.Int(nullable: false),
                        SourceUrl = c.String(),
                        ProcessedAt = c.DateTime(nullable: false),
                        DeviceId = c.String(),
                        Phone = c.String(),
                        CustomerLocale = c.String(),
                        AppId = c.String(),
                        BrowserIp = c.String(),
                        LandingSiteRef = c.String(),
                        OrderNumber = c.Long(nullable: false),
                        ProcessingMethod = c.String(),
                        CheckoutId = c.String(),
                        SourceName = c.String(),
                        FulfillmentStatus = c.String(),
                        Tags = c.String(),
                        ContactEmail = c.String(),
                        OrderStatusUrl = c.String(),
                        BillingAddress_Id = c.Long(),
                        Customer_Id = c.Long(),
                        ShippingAddress_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.BillingAddress_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddress_Id)
                .Index(t => t.BillingAddress_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.ShippingAddress_Id);
            
            CreateTable(
                "dbo.ShippingLines",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.String(),
                        Code = c.String(),
                        Source = c.String(),
                        Phone = c.String(),
                        RequestedFulfillmentServiceId = c.Int(nullable: false),
                        DeliveryCategory = c.Int(nullable: false),
                        CarrierIdentifier = c.String(),
                        DiscountedPrice = c.String(),
                        Order_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        BodyHtml = c.String(),
                        Vendor = c.String(),
                        ProductType = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Handle = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        PublishedAt = c.DateTime(nullable: false),
                        TemplateSuffix = c.String(),
                        Tags = c.String(),
                        PublishedScope = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Variants",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductId = c.Long(nullable: false),
                        Title = c.String(),
                        Price = c.String(),
                        Sku = c.String(),
                        Position = c.Long(nullable: false),
                        InventoryPolicy = c.String(),
                        CompareAtPrice = c.String(),
                        FulfillmentService = c.String(),
                        InventoryManagement = c.String(),
                        Option1 = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Taxable = c.Boolean(nullable: false),
                        Barcode = c.String(),
                        Grams = c.Long(nullable: false),
                        ImageId = c.Int(nullable: false),
                        InventoryQuantity = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        WeightUnit = c.String(),
                        InventoryItemId = c.String(),
                        OldInventoryQuantity = c.Int(nullable: false),
                        RequiresShipping = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Variants", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Options", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Images", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ShippingLines", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShippingAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.LineItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "BillingAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.Customers", "DefaultAddress_Id", "dbo.Addresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Variants", new[] { "ProductId" });
            DropIndex("dbo.ShippingLines", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "ShippingAddress_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "BillingAddress_Id" });
            DropIndex("dbo.Options", new[] { "ProductId" });
            DropIndex("dbo.LineItems", new[] { "Order_Id" });
            DropIndex("dbo.Images", new[] { "ProductId" });
            DropIndex("dbo.Customers", new[] { "DefaultAddress_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Variants");
            DropTable("dbo.Products");
            DropTable("dbo.ShippingLines");
            DropTable("dbo.Orders");
            DropTable("dbo.Options");
            DropTable("dbo.LineItems");
            DropTable("dbo.Images");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
