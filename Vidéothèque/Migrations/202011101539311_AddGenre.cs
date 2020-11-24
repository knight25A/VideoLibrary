namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre : DbMigration
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
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Disaster')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Documentary')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (14, 'Sci-fi')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (15, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (16, 'War')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (17, 'Western')");

        }

        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
