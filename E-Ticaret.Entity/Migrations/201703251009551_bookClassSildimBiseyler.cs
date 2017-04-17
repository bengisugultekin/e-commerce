namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookClassSildimBiseyler : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "PublishYear");
            DropColumn("dbo.Books", "PageCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "PageCount", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "PublishYear", c => c.String());
        }
    }
}
