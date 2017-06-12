namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmailAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "RenewedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "ExpireOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "EmailAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "EmailAddress", c => c.String());
            DropColumn("dbo.Companies", "ExpireOn");
            DropColumn("dbo.Companies", "RenewedOn");
        }
    }
}
