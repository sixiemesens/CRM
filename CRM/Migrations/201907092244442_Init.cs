namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Shops",
                c => new
                    {
                        ShopId = c.Int(nullable: false, identity: true),
                        Address_StreetName = c.String(),
                        Address_number = c.Int(nullable: false),
                        Address_City = c.String(),
                        Address_ZipCode = c.String(),
                        Address_Attitude = c.String(),
                        Address_Lattitude = c.String(),
                        ShopName = c.String(),
                        ShopPhone = c.String(),
                        ShopType = c.String(),
                        OpeningTime = c.String(),
                    })
                .PrimaryKey(t => t.ShopId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ShopId = c.Int(nullable: false),
                        Stocknbr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ShopId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ShopId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        Photo = c.String(),
                        ProductCategory = c.String(),
                        ProductBrand = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        MotDePasse = c.String(),
                        ConfirmMotDePasse = c.String(),
                        role = c.Int(nullable: false),
                        companyFK = c.Int(nullable: false),
                        shopFK = c.Int(nullable: false),
                        company_CompanyId = c.Int(),
                        shop_ShopId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Companies", t => t.company_CompanyId)
                .ForeignKey("dbo.Shops", t => t.shop_ShopId)
                .Index(t => t.company_CompanyId)
                .Index(t => t.shop_ShopId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        logo = c.String(),
                        CampanyName = c.String(),
                        theme = c.String(),
                        phone = c.Int(nullable: false),
                        Address_StreetName = c.String(),
                        Address_number = c.Int(nullable: false),
                        Address_City = c.String(),
                        Address_ZipCode = c.String(),
                        Address_Attitude = c.String(),
                        Address_Lattitude = c.String(),
                        Activated = c.Boolean(nullable: false),
                        TaxNumber = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyModules",
                c => new
                    {
                        CompanyId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        AcquisitionDate = c.DateTime(nullable: false),
                        etat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyId, t.ModuleId })
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ModuleName = c.String(),
                        price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId);
            
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
            DropForeignKey("dbo.Users", "shop_ShopId", "dbo.Shops");
            DropForeignKey("dbo.Users", "company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyModules", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.CompanyModules", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Stocks", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CompanyModules", new[] { "ModuleId" });
            DropIndex("dbo.CompanyModules", new[] { "CompanyId" });
            DropIndex("dbo.Users", new[] { "shop_ShopId" });
            DropIndex("dbo.Users", new[] { "company_CompanyId" });
            DropIndex("dbo.Stocks", new[] { "ShopId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Modules");
            DropTable("dbo.CompanyModules");
            DropTable("dbo.Companies");
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Stocks");
            DropTable("dbo.Shops");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
