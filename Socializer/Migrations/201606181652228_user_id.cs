namespace Socializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_id : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FriendRequest", name: "ReceiverID", newName: "SUser_Id");
            RenameIndex(table: "dbo.FriendRequest", name: "IX_ReceiverID", newName: "IX_SUser_Id");
            AddColumn("dbo.FriendRequest", "SUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.FriendRequest", "SUserID");
            AddForeignKey("dbo.FriendRequest", "SUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FriendRequest", "SUserID", "dbo.AspNetUsers");
            DropIndex("dbo.FriendRequest", new[] { "SUserID" });
            DropColumn("dbo.FriendRequest", "SUserID");
            RenameIndex(table: "dbo.FriendRequest", name: "IX_SUser_Id", newName: "IX_ReceiverID");
            RenameColumn(table: "dbo.FriendRequest", name: "SUser_Id", newName: "ReceiverID");
        }
    }
}
