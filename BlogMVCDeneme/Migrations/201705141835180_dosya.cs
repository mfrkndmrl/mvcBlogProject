namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dosya : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Makales", "Dosya", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Makales", "Dosya");
        }
    }
}
