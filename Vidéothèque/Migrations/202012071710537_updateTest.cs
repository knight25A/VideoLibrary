namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Rents", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoices", "MovieId");
            CreateIndex("dbo.Rents", "InvoiceId");
            AddForeignKey("dbo.Invoices", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
            DropColumn("dbo.Invoices", "IdFilm");
            DropColumn("dbo.Rents", "IdInvoice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "IdInvoice", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "IdFilm", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rents", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "MovieId", "dbo.Movies");
            DropIndex("dbo.Rents", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "MovieId" });
            DropColumn("dbo.Rents", "InvoiceId");
            DropColumn("dbo.Invoices", "MovieId");
        }
    }
}
