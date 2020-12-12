namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.Invoices", "MovieId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Movies", "Synopsis", c => c.String());
            AddColumn("dbo.Movies", "Actors", c => c.String());
            AddColumn("dbo.Movies", "ImagePath", c => c.String());
            AddColumn("dbo.Movies", "ImagePoster", c => c.String());
            AddColumn("dbo.Rents", "InvoiceId", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            CreateIndex("dbo.Invoices", "MovieId");
            CreateIndex("dbo.Invoices", "UserId");
            CreateIndex("dbo.Rents", "InvoiceId");
            AddForeignKey("dbo.Invoices", "MovieId", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Invoices", "IdFilm");
            DropColumn("dbo.Invoices", "IdUser");
            DropColumn("dbo.Rents", "IdInvoice");
            DropTable("dbo.Customers");
            DropTable("dbo.MembershipTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Surname = c.String(nullable: false, maxLength: 25),
                        isSubscribedToNewletter = c.Boolean(nullable: false),
                        MembershipTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Rents", "IdInvoice", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "IdUser", c => c.String(nullable: false));
            AddColumn("dbo.Invoices", "IdFilm", c => c.Int(nullable: false));
            DropForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rents", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "MovieId", "dbo.Movies");
            DropIndex("dbo.Rents", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropIndex("dbo.Invoices", new[] { "MovieId" });
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Rents", "InvoiceId");
            DropColumn("dbo.Movies", "ImagePoster");
            DropColumn("dbo.Movies", "ImagePath");
            DropColumn("dbo.Movies", "Actors");
            DropColumn("dbo.Movies", "Synopsis");
            DropColumn("dbo.Invoices", "UserId");
            DropColumn("dbo.Invoices", "MovieId");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
