namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VZ : DbMigration
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
                        Email = c.String(),
                        MotDePasse = c.String(),
                        ConfirmMotDePasse = c.String(),
                        role = c.Int(nullable: false),
                        companyFK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Companies", t => t.companyFK, cascadeDelete: true)
                .Index(t => t.companyFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "companyFK", "dbo.Companies");
            DropForeignKey("dbo.CompanyModules", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.CompanyModules", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "companyFK" });
            DropIndex("dbo.CompanyModules", new[] { "ModuleId" });
            DropIndex("dbo.CompanyModules", new[] { "CompanyId" });
            DropTable("dbo.Users");
            DropTable("dbo.Modules");
            DropTable("dbo.CompanyModules");
            DropTable("dbo.Companies");
        }
    }
}
