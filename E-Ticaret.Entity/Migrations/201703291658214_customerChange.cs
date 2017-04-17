namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "BirthDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
