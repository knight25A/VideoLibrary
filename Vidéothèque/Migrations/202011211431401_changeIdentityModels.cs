namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeIdentityModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Age", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
