namespace Zomato.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        CName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Spicyness = c.Int(nullable: false),
                        Image = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.MenuItems", new[] { "SubCategoryId" });
            DropIndex("dbo.MenuItems", new[] { "CategoryId" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Categories");
        }
    }
}
