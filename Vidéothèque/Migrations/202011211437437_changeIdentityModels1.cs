namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIdentityModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "Pseudo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Pseudo", c => c.String());
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
