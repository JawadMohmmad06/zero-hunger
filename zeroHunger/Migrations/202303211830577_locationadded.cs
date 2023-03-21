namespace zeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectRequests", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectRequests", "Location");
        }
    }
}
