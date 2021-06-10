namespace BlogMVCDeneme.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hata5 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.MakaleEtikets");
            DropTable("dbo.MakaleKategoris");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MakaleKategoris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakaleId = c.Int(nullable: false),
                        KategoriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MakaleEtikets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakaleId = c.Int(nullable: false),
                        EtiketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
