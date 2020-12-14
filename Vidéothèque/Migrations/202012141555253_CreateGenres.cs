namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Byte(nullable: false),
                    Name = c.String(nullable: false, maxLength: 25),
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Biopic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Cartoon')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Disaster')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (15, 'Sci-fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (16, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (17, 'War')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (18, 'Western')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
