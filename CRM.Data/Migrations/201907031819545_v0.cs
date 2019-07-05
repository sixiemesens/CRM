namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        ClaimType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        ClaimSubject = c.String(),
                        Description = c.String(),
                        ClaimStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ClaimId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        NomComplet_Nom = c.String(),
                        NomComplet_Prenom = c.String(),
                        CustomerAddress_StreetName = c.String(),
                        CustomerAddress_number = c.Int(nullable: false),
                        CustomerAddress_City = c.String(),
                        CustomerAddress_ZipCode = c.String(),
                        CustomerAddress_Attitude = c.String(),
                        CustomerAddress_Lattitude = c.String(),
                        sexe = c.Int(nullable: false),
                        Email = c.String(),
                        CustomerPhone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
            DropTable("dbo.Claims");
        }
    }
}
