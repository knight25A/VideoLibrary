namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rents", "ApplicationUser_Id");
            AddForeignKey("dbo.Rents", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rents", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Rents", "ApplicationUser_Id");
        }
    }
}
