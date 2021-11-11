namespace Zomato.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Historofcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HistorySummaries", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.MenuItems", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.HistorySummaries",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderTotal = c.Double(nullable: false),
                        PickUpTime = c.DateTime(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                        PaymentStatus = c.String(nullable: false),
                        TransactionId = c.String(nullable: false),
                        ApplicationUserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "MenuId", "dbo.MenuItems");
            DropForeignKey("dbo.Histories", "OrderId", "dbo.HistorySummaries");
            DropIndex("dbo.Histories", new[] { "OrderId" });
            DropIndex("dbo.Histories", new[] { "MenuId" });
            DropTable("dbo.HistorySummaries");
            DropTable("dbo.Histories");
        }
    }
}
