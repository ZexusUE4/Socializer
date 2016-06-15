namespace Socializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adding_MaritalStatuses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MaritalStatus", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MaritalStatus");
        }
    }
}
