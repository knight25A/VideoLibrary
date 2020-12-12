namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsInvoceRent5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Invoices", new[] { "Movie_Id" });
            RenameColumn(table: "dbo.Invoices", name: "Movie_Id", newName: "MovieId");
            AlterColumn("dbo.Invoices", "MovieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "MovieId");
            AddForeignKey("dbo.Invoices", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "MovieId", "dbo.Movies");
            DropIndex("dbo.Invoices", new[] { "MovieId" });
            AlterColumn("dbo.Invoices", "MovieId", c => c.Int());
            RenameColumn(table: "dbo.Invoices", name: "MovieId", newName: "Movie_Id");
            CreateIndex("dbo.Invoices", "Movie_Id");
            AddForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
