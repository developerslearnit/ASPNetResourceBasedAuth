namespace AuthApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        ResourceId = c.Int(nullable: false, identity: true),
                        Controller = c.String(nullable: false, maxLength: 50),
                        Action = c.String(nullable: false, maxLength: 50),
                        Area = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ResourceId);
            
            CreateTable(
                "dbo.RoleResources",
                c => new
                    {
                        RoleResourceId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        ResourceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleResourceId)
                .ForeignKey("dbo.Resources", t => t.ResourceId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ResourceId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        User_ApplicationUserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.User_ApplicationUserId)
                .Index(t => t.RoleId)
                .Index(t => t.User_ApplicationUserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        ApplicationUserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "User_ApplicationUserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleResources", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoleResources", "ResourceId", "dbo.Resources");
            DropIndex("dbo.UserRoles", new[] { "User_ApplicationUserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.RoleResources", new[] { "ResourceId" });
            DropIndex("dbo.RoleResources", new[] { "RoleId" });
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.RoleResources");
            DropTable("dbo.Resources");
        }
    }
}
