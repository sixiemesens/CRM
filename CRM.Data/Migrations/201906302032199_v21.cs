namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerAddress_StreetName = c.String(),
                        CustomerAddress_number = c.Int(nullable: false),
                        CustomerAddress_City = c.String(),
                        CustomerAddress_ZipCode = c.String(),
                        CustomerAddress_Attitude = c.String(),
                        CustomerAddress_Lattitude = c.String(),
                        sexe = c.Int(nullable: false),
                        CustomerPhone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.CustomersClaims",
                c => new
                    {
                        Customers_CustomerId = c.Int(nullable: false),
                        Claims_ClaimId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customers_CustomerId, t.Claims_ClaimId })
                .ForeignKey("dbo.Customers", t => t.Customers_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Claims", t => t.Claims_ClaimId, cascadeDelete: true)
                .Index(t => t.Customers_CustomerId)
                .Index(t => t.Claims_ClaimId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomersClaims", "Claims_ClaimId", "dbo.Claims");
            DropForeignKey("dbo.CustomersClaims", "Customers_CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomersClaims", new[] { "Claims_ClaimId" });
            DropIndex("dbo.CustomersClaims", new[] { "Customers_CustomerId" });
            DropTable("dbo.CustomersClaims");
            DropTable("dbo.Customers");
        }
    }
}
