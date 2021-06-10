namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hataduzelt4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Makales", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Makales", name: "IX_UserId", newName: "IX_User_Id");
            AddColumn("dbo.Makales", "KullaniciId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makales", "KullaniciId");
            RenameIndex(table: "dbo.Makales", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Makales", name: "User_Id", newName: "UserId");
        }
    }
}
