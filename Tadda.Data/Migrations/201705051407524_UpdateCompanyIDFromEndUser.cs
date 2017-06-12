namespace Tadda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCompanyIDFromEndUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "EndUser_EndUserId", "dbo.EndUsers");
            DropIndex("dbo.Companies", new[] { "EndUser_EndUserId" });
            AddColumn("dbo.EndUsers", "CompanyId", c => c.Int(nullable: false));
            AddColumn("dbo.EndUsers", "DateTimeCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Companies", "EndUser_EndUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "EndUser_EndUserId", c => c.Int());
            DropColumn("dbo.EndUsers", "DateTimeCreated");
            DropColumn("dbo.EndUsers", "CompanyId");
            CreateIndex("dbo.Companies", "EndUser_EndUserId");
            AddForeignKey("dbo.Companies", "EndUser_EndUserId", "dbo.EndUsers", "EndUserId");
        }
    }
}
