namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hataduzelt1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakaleId = c.Int(nullable: false),
                        EtiketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Etikets", t => t.EtiketId, cascadeDelete: true)
                .ForeignKey("dbo.Makales", t => t.MakaleId, cascadeDelete: true)
                .Index(t => t.MakaleId)
                .Index(t => t.EtiketId);
            
            CreateTable(
                "dbo.MakaleKategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakaleId = c.Int(nullable: false),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kategoris", t => t.KategoriId, cascadeDelete: true)
                .ForeignKey("dbo.Makales", t => t.MakaleId, cascadeDelete: true)
                .Index(t => t.MakaleId)
                .Index(t => t.KategoriId);
            
            AddColumn("dbo.Makales", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Makales", "UserId");
            AddForeignKey("dbo.Makales", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MakaleKategoris", "MakaleId", "dbo.Makales");
            DropForeignKey("dbo.MakaleKategoris", "KategoriId", "dbo.Kategoris");
            DropForeignKey("dbo.MakaleEtikets", "MakaleId", "dbo.Makales");
            DropForeignKey("dbo.Makales", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MakaleEtikets", "EtiketId", "dbo.Etikets");
            DropIndex("dbo.MakaleKategoris", new[] { "KategoriId" });
            DropIndex("dbo.MakaleKategoris", new[] { "MakaleId" });
            DropIndex("dbo.Makales", new[] { "UserId" });
            DropIndex("dbo.MakaleEtikets", new[] { "EtiketId" });
            DropIndex("dbo.MakaleEtikets", new[] { "MakaleId" });
            DropColumn("dbo.Makales", "UserId");
            DropTable("dbo.MakaleKategoris");
            DropTable("dbo.MakaleEtikets");
        }
    }
}
