namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "company_CompanyId", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "company_CompanyId" });
            DropColumn("dbo.Users", "companyFK");
            RenameColumn(table: "dbo.Users", name: "company_CompanyId", newName: "companyFK");
            AlterColumn("dbo.Users", "companyFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "companyFK");
            AddForeignKey("dbo.Users", "companyFK", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "companyFK", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "companyFK" });
            AlterColumn("dbo.Users", "companyFK", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "companyFK", newName: "company_CompanyId");
            AddColumn("dbo.Users", "companyFK", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "company_CompanyId");
            AddForeignKey("dbo.Users", "company_CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
