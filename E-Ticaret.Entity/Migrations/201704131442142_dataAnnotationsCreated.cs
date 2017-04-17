namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotationsCreated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Customers", "Surname", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Surname", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
