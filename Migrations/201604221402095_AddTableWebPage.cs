namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableWebPage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WebPage",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SourceUrl = c.String(unicode: false),
                        StaticUrl = c.String(unicode: false),
                        WillGenerate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WebPage");
        }
    }
}
