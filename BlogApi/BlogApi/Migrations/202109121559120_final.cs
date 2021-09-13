namespace BlogApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "User_UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "User_UserId" });
            DropColumn("dbo.Comments", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "User_UserId", c => c.Int());
            CreateIndex("dbo.Comments", "User_UserId");
            AddForeignKey("dbo.Comments", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
