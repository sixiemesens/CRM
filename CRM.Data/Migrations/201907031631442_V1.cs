namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
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
                        AcquisitionDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
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
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName_nom = c.String(),
                        UserName_prenom = c.String(),
                        Email = c.String(),
                        MotDePasse = c.String(),
                        ConfirmMotDePasse = c.String(),
                        role = c.Int(nullable: false),
                        companyFK = c.Int(nullable: false),
                        shopFK = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Shops", t => t.shopFK)
                .ForeignKey("dbo.Companies", t => t.companyFK, cascadeDelete: true)
                .Index(t => t.companyFK)
                .Index(t => t.shopFK);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "companyFK", "dbo.Companies");
            DropForeignKey("dbo.Users", "shopFK", "dbo.Shops");
            DropForeignKey("dbo.Stocks", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CompanyModules", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.CompanyModules", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Stocks", new[] { "ShopId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Users", new[] { "shopFK" });
            DropIndex("dbo.Users", new[] { "companyFK" });
            DropIndex("dbo.CompanyModules", new[] { "ModuleId" });
            DropIndex("dbo.CompanyModules", new[] { "CompanyId" });
            DropTable("dbo.Products");
            DropTable("dbo.Stocks");
            DropTable("dbo.Shops");
            DropTable("dbo.Users");
            DropTable("dbo.Modules");
            DropTable("dbo.CompanyModules");
            DropTable("dbo.Companies");
        }
    }
}
