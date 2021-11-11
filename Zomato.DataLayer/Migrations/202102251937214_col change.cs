namespace Zomato.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.ShoppingCarts", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "Count", c => c.Int(nullable: false));
            DropColumn("dbo.ShoppingCarts", "Quantity");
        }
    }
}
