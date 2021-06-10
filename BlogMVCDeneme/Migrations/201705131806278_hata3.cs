namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hata3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MakaleEtikets", "EtiketId", "dbo.Etikets");
            DropForeignKey("dbo.MakaleEtikets", "MakaleId", "dbo.Makales");
            DropIndex("dbo.MakaleEtikets", new[] { "MakaleId" });
            DropIndex("dbo.MakaleEtikets", new[] { "EtiketId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MakaleEtikets", "EtiketId");
            CreateIndex("dbo.MakaleEtikets", "MakaleId");
            AddForeignKey("dbo.MakaleEtikets", "MakaleId", "dbo.Makales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MakaleEtikets", "EtiketId", "dbo.Etikets", "Id", cascadeDelete: true);
        }
    }
}
