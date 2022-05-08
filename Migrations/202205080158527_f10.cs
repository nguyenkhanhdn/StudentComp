namespace StudentComp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recommends", "RecommendArticle", c => c.String());
            AddColumn("dbo.Recommends", "Hit", c => c.Int(nullable: false));
            AddColumn("dbo.Recommends", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recommends", "CreatedDate");
            DropColumn("dbo.Recommends", "Hit");
            DropColumn("dbo.Recommends", "RecommendArticle");
        }
    }
}
