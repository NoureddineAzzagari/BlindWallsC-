namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMuralandArtist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistID = c.Int(nullable: false, identity: true),
                        ArtistName = c.String(nullable: false),
                        AristPassword = c.String(),
                    })
                .PrimaryKey(t => t.ArtistID);
            
            CreateTable(
                "dbo.Murals",
                c => new
                    {
                        MuralId = c.Int(nullable: false, identity: true),
                        MuralName = c.String(),
                        MuralDescription = c.String(),
                        ArtistID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MuralId)
                .ForeignKey("dbo.Artists", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Murals", "ArtistID", "dbo.Artists");
            DropIndex("dbo.Murals", new[] { "ArtistID" });
            DropTable("dbo.Murals");
            DropTable("dbo.Artists");
        }
    }
}
