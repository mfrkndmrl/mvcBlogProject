namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class durum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Makales", "Durum", c => c.Boolean(nullable: false));
            AddColumn("dbo.Makales", "DurumAciklama", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makales", "DurumAciklama");
            DropColumn("dbo.Makales", "Durum");
        }
    }
}
