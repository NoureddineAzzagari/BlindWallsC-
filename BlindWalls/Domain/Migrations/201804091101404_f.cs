namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleDescription = c.String(),
                        RoleName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            AddColumn("dbo.Artists", "Account_AccountID", c => c.Int());
            CreateIndex("dbo.Artists", "Account_AccountID");
            AddForeignKey("dbo.Artists", "Account_AccountID", "dbo.Accounts", "AccountID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Artists", "Account_AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "RoleID", "dbo.Roles");
            DropIndex("dbo.Accounts", new[] { "RoleID" });
            DropIndex("dbo.Artists", new[] { "Account_AccountID" });
            DropColumn("dbo.Artists", "Account_AccountID");
            DropTable("dbo.Roles");
            DropTable("dbo.Accounts");
        }
    }
}
