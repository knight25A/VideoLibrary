namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCounterRent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NbRent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NbRent");
        }
    }
}
