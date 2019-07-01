namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        ClaimId = c.Int(nullable: false, identity: true),
                        ClaimSubject = c.String(),
                        description = c.String(),
                        ClaimStartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.Int(nullable: false),
                        ClaimType = c.String(),
                    })
                .PrimaryKey(t => t.ClaimId);
            
            CreateTable(
                "dbo.ClaimsUsers",
                c => new
                    {
                        Claims_ClaimId = c.Int(nullable: false),
                        Users_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Claims_ClaimId, t.Users_UserId })
                .ForeignKey("dbo.Claims", t => t.Claims_ClaimId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Users_UserId, cascadeDelete: true)
                .Index(t => t.Claims_ClaimId)
                .Index(t => t.Users_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClaimsUsers", "Users_UserId", "dbo.Users");
            DropForeignKey("dbo.ClaimsUsers", "Claims_ClaimId", "dbo.Claims");
            DropIndex("dbo.ClaimsUsers", new[] { "Users_UserId" });
            DropIndex("dbo.ClaimsUsers", new[] { "Claims_ClaimId" });
            DropTable("dbo.ClaimsUsers");
            DropTable("dbo.Claims");
        }
    }
}
