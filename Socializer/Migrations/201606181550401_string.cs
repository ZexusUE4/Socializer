namespace Socializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _string : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FriendRequest", "Reciver_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.FriendRequest", "SenderID", c => c.String(maxLength: 128));
            AlterColumn("dbo.FriendRequest", "RecieverID", c => c.String());
            CreateIndex("dbo.FriendRequest", "SenderID");
            CreateIndex("dbo.FriendRequest", "Reciver_Id");
            AddForeignKey("dbo.FriendRequest", "Reciver_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.FriendRequest", "SenderID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequest", "SenderID", "dbo.AspNetUsers");
            DropForeignKey("dbo.FriendRequest", "Reciver_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequest", new[] { "Reciver_Id" });
            DropIndex("dbo.FriendRequest", new[] { "SenderID" });
            AlterColumn("dbo.FriendRequest", "RecieverID", c => c.Int());
            AlterColumn("dbo.FriendRequest", "SenderID", c => c.Int());
            DropColumn("dbo.FriendRequest", "Reciver_Id");
        }
    }
}
