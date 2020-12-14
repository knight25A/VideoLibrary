namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rents",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    InvoiceId = c.Int(nullable: false),
                    UserId = c.String(nullable: false),
                    DateLocation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    ExpectedReturnDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    Status = c.String(),
                    ApplicationUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.InvoiceId)
                .Index(t => t.ApplicationUser_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rents", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.Rents", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Rents", new[] { "InvoiceId" });
            DropTable("dbo.Rents");
        }
    }
}
