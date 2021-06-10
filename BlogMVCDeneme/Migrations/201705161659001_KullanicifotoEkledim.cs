namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullanicifotoEkledim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Fotograf", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Fotograf");
        }
    }
}
