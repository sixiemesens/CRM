namespace CRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nml : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName_nom", c => c.String());
            AddColumn("dbo.Users", "UserName_prenom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserName_prenom");
            DropColumn("dbo.Users", "UserName_nom");
        }
    }
}
