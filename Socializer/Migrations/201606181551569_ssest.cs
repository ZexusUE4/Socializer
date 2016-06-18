namespace Socializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssest : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.FriendRequest", name: "Reciver_Id", newName: "ReceiverID");
            RenameIndex(table: "dbo.FriendRequest", name: "IX_Reciver_Id", newName: "IX_ReceiverID");
            DropColumn("dbo.FriendRequest", "RecieverID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FriendRequest", "RecieverID", c => c.String());
            RenameIndex(table: "dbo.FriendRequest", name: "IX_ReceiverID", newName: "IX_Reciver_Id");
            RenameColumn(table: "dbo.FriendRequest", name: "ReceiverID", newName: "Reciver_Id");
        }
    }
}
