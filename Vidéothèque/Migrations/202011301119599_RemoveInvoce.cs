namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveInvoce : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Invoices", new[] { "Movie_Id" });
            DropIndex("dbo.Invoices", new[] { "User_Id" });
            DropColumn("dbo.Invoices", "Movie_Id");
            DropColumn("dbo.Invoices", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Invoices", "Movie_Id", c => c.Int());
            CreateIndex("dbo.Invoices", "User_Id");
            CreateIndex("dbo.Invoices", "Movie_Id");
            AddForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
