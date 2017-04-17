namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
            AddColumn("dbo.Customers", "Surname", c => c.String());
            AddColumn("dbo.Customers", "Phone", c => c.String());
            AddColumn("dbo.Customers", "Email", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "NameSurname");
            DropColumn("dbo.Customers", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Customers", "NameSurname", c => c.String());
            DropColumn("dbo.Customers", "BirthDay");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Email");
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "Surname");
            DropColumn("dbo.Customers", "Name");
        }
    }
}
