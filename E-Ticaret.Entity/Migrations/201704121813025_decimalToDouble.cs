namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decimalToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Books", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
