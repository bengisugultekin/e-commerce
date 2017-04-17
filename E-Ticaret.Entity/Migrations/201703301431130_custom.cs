namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class custom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customs", "OrderDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customs", "OrderDate");
        }
    }
}
