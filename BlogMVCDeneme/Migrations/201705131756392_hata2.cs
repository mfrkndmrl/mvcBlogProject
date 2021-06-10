namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hata2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MakaleKategoris", "KategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.MakaleKategoris", "MakaleId", "dbo.Makales");
            DropIndex("dbo.MakaleKategoris", new[] { "MakaleId" });
            DropIndex("dbo.MakaleKategoris", new[] { "KategoriId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.MakaleKategoris", "KategoriId");
            CreateIndex("dbo.MakaleKategoris", "MakaleId");
            AddForeignKey("dbo.MakaleKategoris", "MakaleId", "dbo.Makales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MakaleKategoris", "KategoriId", "dbo.Kategoris", "Id", cascadeDelete: true);
        }
    }
}
