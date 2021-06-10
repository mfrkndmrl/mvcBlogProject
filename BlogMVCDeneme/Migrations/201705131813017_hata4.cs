namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hata4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Makales", "Baslik", c => c.String());
            DropColumn("dbo.Makales", "MakaleBaslik");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Makales", "MakaleBaslik", c => c.String());
            DropColumn("dbo.Makales", "Baslik");
        }
    }
}
