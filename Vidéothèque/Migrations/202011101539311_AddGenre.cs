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

            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Commedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Crime')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Cartoon')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (8, 'Musical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (9, 'War')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (10, 'Fantasy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (11, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (12, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (13, 'Western')");

        }

        public override void Down()
        {
            DropTable("dbo.Genres");
        }
    }
}
