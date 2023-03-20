namespace zeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestProcessings", "Location", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestProcessings", "Location");
        }
    }
}
