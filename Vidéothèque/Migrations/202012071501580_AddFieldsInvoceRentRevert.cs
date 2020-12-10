namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsInvoceRentRevert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Rents", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Invoices", new[] { "Movie_Id" });
            DropIndex("dbo.Invoices", new[] { "User_Id" });
            DropIndex("dbo.Rents", new[] { "Invoice_Id" });
            DropColumn("dbo.Invoices", "Movie_Id");
            DropColumn("dbo.Invoices", "User_Id");
            DropColumn("dbo.Rents", "Invoice_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "Invoice_Id", c => c.Int());
            AddColumn("dbo.Invoices", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Invoices", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Rents", "Invoice_Id");
            CreateIndex("dbo.Invoices", "User_Id");
            CreateIndex("dbo.Invoices", "Movie_Id");
            AddForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Rents", "Invoice_Id", "dbo.Invoices", "Id");
            AddForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
