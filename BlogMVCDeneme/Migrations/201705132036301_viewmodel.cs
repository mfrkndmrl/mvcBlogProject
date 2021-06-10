namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class viewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MakaleYorumViews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Makale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makales", t => t.Makale_Id)
                .Index(t => t.Makale_Id);
            
            CreateTable(
                "dbo.Yorums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UstId = c.Int(nullable: false),
                        YorumMetni = c.String(),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Email = c.String(),
                        YorumTarihi = c.DateTime(nullable: false),
                        MakaleId = c.Int(nullable: false),
                        MakaleYorumView_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MakaleYorumViews", t => t.MakaleYorumView_Id)
                .Index(t => t.MakaleYorumView_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorums", "MakaleYorumView_Id", "dbo.MakaleYorumViews");
            DropForeignKey("dbo.MakaleYorumViews", "Makale_Id", "dbo.Makales");
            DropIndex("dbo.Yorums", new[] { "MakaleYorumView_Id" });
            DropIndex("dbo.MakaleYorumViews", new[] { "Makale_Id" });
            DropTable("dbo.Yorums");
            DropTable("dbo.MakaleYorumViews");
        }
    }
}
