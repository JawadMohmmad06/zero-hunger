namespace zeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CollectRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DashboardId = c.Int(nullable: false),
                        ProcessingId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RequestDashboards", t => t.DashboardId, cascadeDelete: true)
                .ForeignKey("dbo.RequestProcessings", t => t.ProcessingId, cascadeDelete: true)
                .Index(t => t.DashboardId)
                .Index(t => t.ProcessingId);
            
            CreateTable(
                "dbo.RequestDashboards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RId = c.Int(nullable: false),
                        FoodName = c.String(),
                        Qty = c.Int(nullable: false),
                        Expirydate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RId, cascadeDelete: true)
                .Index(t => t.RId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestProcessings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EId, cascadeDelete: true)
                .Index(t => t.EId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CollectRequests", "ProcessingId", "dbo.RequestProcessings");
            DropForeignKey("dbo.RequestProcessings", "EId", "dbo.Employees");
            DropForeignKey("dbo.CollectRequests", "DashboardId", "dbo.RequestDashboards");
            DropForeignKey("dbo.RequestDashboards", "RId", "dbo.Restaurants");
            DropIndex("dbo.RequestProcessings", new[] { "EId" });
            DropIndex("dbo.RequestDashboards", new[] { "RId" });
            DropIndex("dbo.CollectRequests", new[] { "ProcessingId" });
            DropIndex("dbo.CollectRequests", new[] { "DashboardId" });
            DropTable("dbo.Employees");
            DropTable("dbo.RequestProcessings");
            DropTable("dbo.Restaurants");
            DropTable("dbo.RequestDashboards");
            DropTable("dbo.CollectRequests");
            DropTable("dbo.Admins");
        }
    }
}
