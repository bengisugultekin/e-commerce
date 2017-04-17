namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customs", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Customs", new[] { "Product_ProductID" });
            DropColumn("dbo.Customs", "Product_ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customs", "Product_ProductID", c => c.Int());
            CreateIndex("dbo.Customs", "Product_ProductID");
            AddForeignKey("dbo.Customs", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
