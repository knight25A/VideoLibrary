namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreMovies : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Price");

            Sql("INSERT INTO Movies (Title, Genre) VALUES ('Gone Girl', 'Drama')");
            Sql("INSERT INTO Movies (Title, Genre) VALUES ('Shutter Island', 'Drama')");
            Sql("INSERT INTO Movies (Title, Genre) VALUES ('Bad Trip', 'Commedy')");
            Sql("INSERT INTO Movies (Title, Genre) VALUES ('Hangover', 'Commedy')");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
