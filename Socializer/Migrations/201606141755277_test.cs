namespace Socializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FriendRequest", "IsPending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FriendRequest", "IsPending", c => c.Boolean(nullable: false));
        }
    }
}
