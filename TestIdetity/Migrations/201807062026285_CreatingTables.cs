namespace TestIdetity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gigs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Venue = c.String(nullable: false, maxLength: 255),
                        DateTime = c.DateTime(nullable: false),
                        Artist_Id = c.String(nullable: false, maxLength: 128),
                        genre_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.genre_Id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "genre_Id" });
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropTable("dbo.Gigs");
            DropTable("dbo.Genres");
        }
    }
}
