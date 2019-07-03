namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packs",
                c => new
                    {
                        PacksId = c.Int(nullable: false, identity: true),
                        PackPrice = c.Single(nullable: false),
                        PackName = c.String(),
                        PackStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        PackEndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.PacksId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OffersId = c.Int(nullable: false),
                        OfferName = c.String(),
                        OfferPrice = c.Single(nullable: false),
                        OfferDescription = c.String(),
                        OfferStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OfferEndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.OffersId)
                .ForeignKey("dbo.Packs", t => t.OffersId)
                .Index(t => t.OffersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "OffersId", "dbo.Packs");
            DropIndex("dbo.Offers", new[] { "OffersId" });
            DropTable("dbo.Offers");
            DropTable("dbo.Packs");
        }
    }
}
