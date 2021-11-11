namespace Zomato.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shoppingcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                        MenuItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId, cascadeDelete: true)
                .Index(t => t.MenuItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "MenuItemId", "dbo.MenuItems");
            DropIndex("dbo.ShoppingCarts", new[] { "MenuItemId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
