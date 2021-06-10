namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editor2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Makales", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Makales", name: "IX_User_Id", newName: "IX_UserId");
            DropColumn("dbo.Makales", "KullaniciId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makales", "KullaniciId", c => c.String());
            RenameIndex(table: "dbo.Makales", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Makales", name: "UserId", newName: "User_Id");
        }
    }
}
