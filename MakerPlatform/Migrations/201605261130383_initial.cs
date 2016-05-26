namespace MakerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IsHref", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "Href", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Href");
            DropColumn("dbo.Articles", "IsHref");
        }
    }
}
