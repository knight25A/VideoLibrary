namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInvoices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MovieId = c.Int(nullable: false),
                    UserId = c.String(nullable: false, maxLength: 128),
                    DateLocation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Quantity = c.Int(nullable: false),
                    TotalPrice = c.Single(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Invoices", "MovieId", "dbo.Movies");
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropIndex("dbo.Invoices", new[] { "MovieId" });
            DropTable("dbo.Invoices");
        }
    }
}
