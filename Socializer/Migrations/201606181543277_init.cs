namespace Socializer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FriendRequest",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(),
                        RecieverID = c.Int(),
                        IsSeen = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Post", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PostOwnerID = c.String(maxLength: 128),
                        Caption = c.String(),
                        ImageURL = c.String(),
                        IsPrivate = c.Boolean(nullable: false),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.PostOwnerID)
                .Index(t => t.PostOwnerID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        HomeTownID = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        MaritalStatus = c.Int(),
                        BirthDate = c.DateTime(),
                        ProfilePicURL = c.String(),
                        AboutMe = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Town", t => t.HomeTownID)
                .Index(t => t.HomeTownID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Town",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.String(maxLength: 128),
                        RecieverID = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        DateIssued = c.DateTime(nullable: false),
                        IsSeen = c.Boolean(nullable: false),
                        SUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.RecieverID)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderID)
                .ForeignKey("dbo.AspNetUsers", t => t.SUser_Id)
                .Index(t => t.SenderID)
                .Index(t => t.RecieverID)
                .Index(t => t.SUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.SUserSUser",
                c => new
                    {
                        SUser_Id = c.String(nullable: false, maxLength: 128),
                        SUser_Id1 = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SUser_Id, t.SUser_Id1 })
                .ForeignKey("dbo.AspNetUsers", t => t.SUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SUser_Id1)
                .Index(t => t.SUser_Id)
                .Index(t => t.SUser_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Like", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Post", "PostOwnerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notification", "SUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notification", "SenderID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notification", "RecieverID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "HomeTownID", "dbo.Town");
            DropForeignKey("dbo.SUserSUser", "SUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.SUserSUser", "SUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Like", "PostID", "dbo.Post");
            DropIndex("dbo.SUserSUser", new[] { "SUser_Id1" });
            DropIndex("dbo.SUserSUser", new[] { "SUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Notification", new[] { "SUser_Id" });
            DropIndex("dbo.Notification", new[] { "RecieverID" });
            DropIndex("dbo.Notification", new[] { "SenderID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "HomeTownID" });
            DropIndex("dbo.Post", new[] { "PostOwnerID" });
            DropIndex("dbo.Like", new[] { "PostID" });
            DropIndex("dbo.Like", new[] { "UserID" });
            DropTable("dbo.SUserSUser");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Notification");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Town");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Post");
            DropTable("dbo.Like");
            DropTable("dbo.FriendRequest");
        }
    }
}
