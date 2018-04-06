namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffsd : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Artists", newName: "Artist");
            RenameTable(name: "dbo.Murals", newName: "Mural");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Mural", newName: "Murals");
            RenameTable(name: "dbo.Artist", newName: "Artists");
        }
    }
}
