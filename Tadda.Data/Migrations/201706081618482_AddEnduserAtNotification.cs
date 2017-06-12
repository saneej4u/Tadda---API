namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnduserAtNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "EnduserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "EnduserId");
        }
    }
}
