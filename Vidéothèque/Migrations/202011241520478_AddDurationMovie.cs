namespace Vidéothèque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDurationMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DurationHours", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "DurationMinutes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DurationMinutes");
            DropColumn("dbo.Movies", "DurationHours");
        }
    }
}
