namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeWithName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
            Sql("UPDATE MembershipTypes SET Name='Pay as you go' where Id=1");
            Sql("UPDATE MembershipTypes SET Name='Monthly' where Id=2");
            Sql("UPDATE MembershipTypes SET Name='3 Months' where Id=3");
            Sql("UPDATE MembershipTypes SET Name='Yearly' where Id=4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
