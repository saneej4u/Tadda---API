namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeviceId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Name = c.String(),
                        Message = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            AddColumn("dbo.EndUsers", "DeviceId", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "OrderId", "dbo.Orders");
            DropIndex("dbo.Notifications", new[] { "OrderId" });
            DropColumn("dbo.EndUsers", "DeviceId");
            DropTable("dbo.Notifications");
        }
    }
}
