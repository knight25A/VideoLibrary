namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addInvoiceRent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdFilm = c.Int(nullable: false),
                        IdUser = c.String(nullable: false),
                        DateLocation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdInvoice = c.Int(nullable: false),
                        IdUser = c.String(nullable: false),
                        DateLocation = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpectedReturnDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rents");
            DropTable("dbo.Invoices");
        }
    }
}
