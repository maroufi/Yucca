namespace Yucca.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        State = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 50),
                        RemnantAddress = c.String(maxLength: 200),
                        PostCode = c.String(nullable: false, maxLength: 20),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PostedDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        TransactionCode = c.String(maxLength: 50),
                        PaymentType = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        BuyerId = c.Long(nullable: false),
                        AddressId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.BuyerId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.BuyerId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        AvatarPath = c.String(maxLength: 200),
                        BirthDay = c.DateTime(),
                        Ip = c.String(maxLength: 20),
                        IsBanned = c.Boolean(nullable: false),
                        BannedDate = c.DateTime(),
                        LastLoginDate = c.DateTime(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Email = c.String(nullable: false, maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(maxLength: 20),
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
                        UserId = c.Long(nullable: false),
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
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MetaDescription = c.String(),
                        Description = c.String(),
                        MetaKeyWords = c.String(),
                        IsFreeShipping = c.Boolean(nullable: false),
                        Stock = c.Int(nullable: false),
                        NotificationStockMinimum = c.Int(nullable: false),
                        SellCount = c.Int(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                        CategoryId = c.Long(nullable: false),
                        ManufacturerId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AttributeOptions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        AttributeId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpecificAttributes", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "dbo.SpecificAttributes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        DisplayOrder = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                        KeyWords = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        ParentId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.CategorySlides",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Path = c.String(),
                        CategoryId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        OrderId = c.Long(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductPictures",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Path = c.String(),
                        IsMainPicture = c.Boolean(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderNotes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Note = c.String(),
                        DisplayToCustomer = c.Boolean(nullable: false),
                        OrderId = c.Long(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Value = c.String(nullable: false, maxLength: 100),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Product_AttributeOption",
                c => new
                    {
                        ProductId = c.Long(nullable: false),
                        AttributeId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.AttributeId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AttributeOptions", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AttributeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Addresses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.OrderNotes", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCarts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ShoppingCarts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPictures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Product_AttributeOption", "AttributeId", "dbo.AttributeOptions");
            DropForeignKey("dbo.Product_AttributeOption", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CategorySlides", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentId", "dbo.Categories");
            DropForeignKey("dbo.SpecificAttributes", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AttributeOptions", "AttributeId", "dbo.SpecificAttributes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Product_AttributeOption", new[] { "AttributeId" });
            DropIndex("dbo.Product_AttributeOption", new[] { "ProductId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderNotes", new[] { "OrderId" });
            DropIndex("dbo.ProductPictures", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.CategorySlides", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "ParentId" });
            DropIndex("dbo.SpecificAttributes", new[] { "CategoryId" });
            DropIndex("dbo.AttributeOptions", new[] { "AttributeId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ShoppingCarts", new[] { "ProductId" });
            DropIndex("dbo.ShoppingCarts", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "AddressId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.Product_AttributeOption");
            DropTable("dbo.Settings");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OrderNotes");
            DropTable("dbo.ProductPictures");
            DropTable("dbo.OrderItems");
            DropTable("dbo.CategorySlides");
            DropTable("dbo.Categories");
            DropTable("dbo.SpecificAttributes");
            DropTable("dbo.AttributeOptions");
            DropTable("dbo.Products");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.Addresses");
        }
    }
}
