namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeNumberAvailabilityInMovieDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailability");
        }
    }
}
