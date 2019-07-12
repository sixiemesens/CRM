namespace CRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategReclams",
                c => new
                    {
                        CategReclamId = c.Int(nullable: false, identity: true),
                        ReclamCateg = c.String(),
                    })
                .PrimaryKey(t => t.CategReclamId);
            
            AddColumn("dbo.Reclamations", "CategReclamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reclamations", "CategReclamId");
            AddForeignKey("dbo.Reclamations", "CategReclamId", "dbo.CategReclams", "CategReclamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reclamations", "CategReclamId", "dbo.CategReclams");
            DropIndex("dbo.Reclamations", new[] { "CategReclamId" });
            DropColumn("dbo.Reclamations", "CategReclamId");
            DropTable("dbo.CategReclams");
        }
    }
}
