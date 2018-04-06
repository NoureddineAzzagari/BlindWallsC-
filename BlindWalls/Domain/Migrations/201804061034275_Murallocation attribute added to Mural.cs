namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MurallocationattributeaddedtoMural : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Murals", "MuralLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Murals", "MuralLocation");
        }
    }
}
