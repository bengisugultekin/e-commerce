namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Product_ProductID" });
            DropColumn("dbo.Customers", "Product_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.Customers", "Product_ProductID");
            AddForeignKey("dbo.Customers", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
