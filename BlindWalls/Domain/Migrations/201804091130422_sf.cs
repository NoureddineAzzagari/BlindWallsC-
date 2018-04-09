namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Artists", "ArtistPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Artists", "ArtistPassword", c => c.String());
        }
    }
}
