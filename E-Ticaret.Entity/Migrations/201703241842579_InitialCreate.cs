namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        BookSubject = c.String(),
                        PageCount = c.Int(nullable: false),
                        WriterID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryID = c.Int(nullable: false),
                        PhotoUrl = c.String(),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID, cascadeDelete: true)
                .Index(t => t.WriterID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterID = c.Int(nullable: false, identity: true),
                        WriterName = c.String(),
                    })
                .PrimaryKey(t => t.WriterID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Address = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BookName = c.String(),
                        BookCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.Books", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Books", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Customers", new[] { "Product_ProductID" });
            DropIndex("dbo.Books", new[] { "CategoryID" });
            DropIndex("dbo.Books", new[] { "WriterID" });
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
            DropTable("dbo.Writers");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
            DropTable("dbo.Admins");
        }
    }
}
