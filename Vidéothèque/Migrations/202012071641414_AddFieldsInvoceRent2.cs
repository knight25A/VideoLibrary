namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsInvoceRent2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Movie_Id", c => c.Int());
            AddColumn("dbo.Rents", "Invoice_Id", c => c.Int());
            CreateIndex("dbo.Invoices", "Movie_Id");
            CreateIndex("dbo.Rents", "Invoice_Id");
            AddForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rents", "Invoice_Id", "dbo.Invoices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Rents", new[] { "Invoice_Id" });
            DropIndex("dbo.Invoices", new[] { "Movie_Id" });
            DropColumn("dbo.Rents", "Invoice_Id");
            DropColumn("dbo.Invoices", "Movie_Id");
        }
    }
}
