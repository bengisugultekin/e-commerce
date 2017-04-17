namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Products", new[] { "Customer_CustomerID" });
            CreateTable(
                "dbo.Customs",
                c => new
                    {
                        CustomID = c.Int(nullable: false, identity: true),
                        TotalBill = c.Double(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            AddColumn("dbo.Products", "Custom_CustomID", c => c.Int());
            CreateIndex("dbo.Products", "Custom_CustomID");
            AddForeignKey("dbo.Products", "Custom_CustomID", "dbo.Customs", "CustomID");
            DropColumn("dbo.Products", "Customer_CustomerID");
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminID);
            
            AddColumn("dbo.Products", "Customer_CustomerID", c => c.Int());
            DropForeignKey("dbo.Customs", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "Custom_CustomID", "dbo.Customs");
            DropIndex("dbo.Products", new[] { "Custom_CustomID" });
            DropIndex("dbo.Customs", new[] { "CustomerID" });
            DropColumn("dbo.Products", "Custom_CustomID");
            DropTable("dbo.Customs");
            CreateIndex("dbo.Products", "Customer_CustomerID");
            AddForeignKey("dbo.Products", "Customer_CustomerID", "dbo.Customers", "CustomerID");
        }
    }
}
