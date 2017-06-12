namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNotMessageDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notifications", "Message", c => c.Int(nullable: false));
        }
    }
}
