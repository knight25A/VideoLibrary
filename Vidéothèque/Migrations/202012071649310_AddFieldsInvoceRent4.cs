namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsInvoceRent4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "MovieId", "dbo.Movies");
            DropIndex("dbo.Invoices", new[] { "MovieId" });
            RenameColumn(table: "dbo.Invoices", name: "MovieId", newName: "Movie_Id");
            AddColumn("dbo.Invoices", "IdFilm", c => c.Int(nullable: false));
            AlterColumn("dbo.Invoices", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Invoices", "Movie_Id");
            AddForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Invoices", new[] { "Movie_Id" });
            AlterColumn("dbo.Invoices", "Movie_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Invoices", "IdFilm");
            RenameColumn(table: "dbo.Invoices", name: "Movie_Id", newName: "MovieId");
            CreateIndex("dbo.Invoices", "MovieId");
            AddForeignKey("dbo.Invoices", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
    }
}
