namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasscode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EndUsers", "PassOne", c => c.Int(nullable: false));
            AddColumn("dbo.EndUsers", "PassTwo", c => c.Int(nullable: false));
            AddColumn("dbo.EndUsers", "PassThree", c => c.Int(nullable: false));
            AddColumn("dbo.EndUsers", "PassFour", c => c.Int(nullable: false));
            AlterColumn("dbo.EndUsers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.EndUsers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.EndUsers", "EmailAddress", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EndUsers", "EmailAddress", c => c.String());
            AlterColumn("dbo.EndUsers", "LastName", c => c.String());
            AlterColumn("dbo.EndUsers", "FirstName", c => c.String());
            DropColumn("dbo.EndUsers", "PassFour");
            DropColumn("dbo.EndUsers", "PassThree");
            DropColumn("dbo.EndUsers", "PassTwo");
            DropColumn("dbo.EndUsers", "PassOne");
        }
    }
}
