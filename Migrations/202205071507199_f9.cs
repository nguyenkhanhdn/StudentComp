namespace StudentComp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recommends",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HandbookId = c.Int(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Recommends");
        }
    }
}
