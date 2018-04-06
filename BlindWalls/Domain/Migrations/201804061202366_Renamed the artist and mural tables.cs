namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamedtheartistandmuraltables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Artist", newName: "Artists");
            RenameTable(name: "dbo.Mural", newName: "Murals");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Murals", newName: "Mural");
            RenameTable(name: "dbo.Artists", newName: "Artist");
        }
    }
}
