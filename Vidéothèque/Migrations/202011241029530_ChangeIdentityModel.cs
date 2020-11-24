namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIdentityModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Rents", "ApplicationUser_Id");
            AddForeignKey("dbo.Rents", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Rents", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.Rents", "ApplicationUser_Id");
        }
    }
}
