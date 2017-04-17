namespace E_Ticaret.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SınıflardaDegisiklik : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Publisher", c => c.String());
            AddColumn("dbo.Books", "PublishYear", c => c.String());
            AddColumn("dbo.Products", "PhotoUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PhotoUrl");
            DropColumn("dbo.Books", "PublishYear");
            DropColumn("dbo.Books", "Publisher");
        }
    }
}
