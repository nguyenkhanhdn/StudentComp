namespace StudentComp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "HandbookId", "dbo.Handbooks");
            DropIndex("dbo.Comments", new[] { "HandbookId" });
            AlterColumn("dbo.Comments", "HandbookId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Comments", "Comment1", c => c.String(nullable: false));
            AlterColumn("dbo.Handbooks", "Brief", c => c.String(nullable: false));
            AlterColumn("dbo.Handbooks", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Handbooks", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Maxims", "Maxim1", c => c.String(nullable: false));
            AlterColumn("dbo.Maxims", "Author", c => c.String(nullable: false));
            CreateIndex("dbo.Comments", "HandbookId");
            AddForeignKey("dbo.Comments", "HandbookId", "dbo.Handbooks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "HandbookId", "dbo.Handbooks");
            DropIndex("dbo.Comments", new[] { "HandbookId" });
            AlterColumn("dbo.Maxims", "Author", c => c.String());
            AlterColumn("dbo.Maxims", "Maxim1", c => c.String());
            AlterColumn("dbo.Handbooks", "Type", c => c.String());
            AlterColumn("dbo.Handbooks", "Content", c => c.String());
            AlterColumn("dbo.Handbooks", "Brief", c => c.String());
            AlterColumn("dbo.Comments", "Comment1", c => c.String());
            AlterColumn("dbo.Comments", "UserName", c => c.String());
            AlterColumn("dbo.Comments", "HandbookId", c => c.Int());
            CreateIndex("dbo.Comments", "HandbookId");
            AddForeignKey("dbo.Comments", "HandbookId", "dbo.Handbooks", "Id");
        }
    }
}
