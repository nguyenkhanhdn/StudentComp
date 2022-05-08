namespace StudentComp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HandbookId = c.Int(),
                        UserName = c.String(),
                        Comment1 = c.String(),
                        CommentDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Handbooks", t => t.HandbookId)
                .Index(t => t.HandbookId);
            
            CreateTable(
                "dbo.Handbooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brief = c.String(),
                        CreatedDate = c.DateTime(),
                        Content = c.String(),
                        Type = c.String(),
                        Hit = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HandbookId = c.Int(),
                        Rate1 = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Handbooks", t => t.HandbookId)
                .Index(t => t.HandbookId);
            
            CreateTable(
                "dbo.Maxims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Maxim1 = c.String(),
                        Author = c.String(),
                        Status = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "HandbookId", "dbo.Handbooks");
            DropForeignKey("dbo.Comments", "HandbookId", "dbo.Handbooks");
            DropIndex("dbo.Rates", new[] { "HandbookId" });
            DropIndex("dbo.Comments", new[] { "HandbookId" });
            DropTable("dbo.Maxims");
            DropTable("dbo.Rates");
            DropTable("dbo.Handbooks");
            DropTable("dbo.Comments");
        }
    }
}
