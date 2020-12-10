namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsInvoceRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Movie_Id", c => c.Int());
            AddColumn("dbo.Invoices", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Invoices", "Movie_Id");
            CreateIndex("dbo.Invoices", "User_Id");
            AddForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Invoices", new[] { "User_Id" });
            DropIndex("dbo.Invoices", new[] { "Movie_Id" });
            DropColumn("dbo.Invoices", "User_Id");
            DropColumn("dbo.Invoices", "Movie_Id");
        }
    }
}
