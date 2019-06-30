namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestocks : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Users", "shopFK", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "shop_ShopId", c => c.Int());
            CreateIndex("dbo.Users", "shop_ShopId");
            AddForeignKey("dbo.Users", "shop_ShopId", "dbo.Shops", "ShopId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "shop_ShopId", "dbo.Shops");
            DropForeignKey("dbo.Stocks", "ShopId", "dbo.Shops");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropIndex("dbo.Stocks", new[] { "ShopId" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.Users", new[] { "shop_ShopId" });
            DropColumn("dbo.Users", "shop_ShopId");
            DropColumn("dbo.Users", "shopFK");
            DropTable("dbo.Products");
            DropTable("dbo.Stocks");
            DropTable("dbo.Shops");
        }
    }
}
