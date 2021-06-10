namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class soruncoz : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KategoriAd = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Makales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakaleBaslik = c.String(),
                        Icerik = c.String(),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Makales", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Makales", new[] { "UserId" });
            DropTable("dbo.Makales");
            DropTable("dbo.Kategoris");
        }
    }
}
