namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 255),
                    Director = c.String(nullable: false, maxLength: 255),
                    Actors = c.String(),
                    Synopsis = c.String(),
                    GenreId = c.Byte(nullable: false),
                    DateAdded = c.DateTime(),
                    ReleaseDate = c.DateTime(),
                    NumberInStock = c.Int(nullable: false),
                    ImagePath = c.String(),
                    ImagePoster = c.String(),
                    DurationHours = c.Int(nullable: false),
                    DurationMinutes = c.Int(nullable: false),
                    Price = c.Single(nullable: false),
                    NbRent = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropTable("dbo.Movies");
        }
    }
}
