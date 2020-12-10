namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Invoices", "UserId");
            AddForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Invoices", "IdUser");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "IdUser", c => c.String(nullable: false));
            DropForeignKey("dbo.Invoices", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropColumn("dbo.Invoices", "UserId");
        }
    }
}
