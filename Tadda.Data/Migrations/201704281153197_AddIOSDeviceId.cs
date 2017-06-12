namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIOSDeviceId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EndUsers", "IOSDeviceId", c => c.String());
            AddColumn("dbo.EndUsers", "AndroidDeviceId", c => c.String());
            DropColumn("dbo.EndUsers", "DeviceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EndUsers", "DeviceId", c => c.String());
            DropColumn("dbo.EndUsers", "AndroidDeviceId");
            DropColumn("dbo.EndUsers", "IOSDeviceId");
        }
    }
}
