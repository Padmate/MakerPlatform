namespace MakerPlatform.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Modifier", c => c.String());
            AddColumn("dbo.Articles", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "ModifiedDate");
            DropColumn("dbo.Articles", "Modifier");
        }
    }
}
