namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hata6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Makales", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Makales", new[] { "UserId" });
            DropColumn("dbo.Makales", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makales", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Makales", "UserId");
            AddForeignKey("dbo.Makales", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
