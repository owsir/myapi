namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTourqueryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tourquery",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        NumberOfPeople = c.Int(nullable: false),
                        Ip = c.String(unicode: false),
                        Device = c.String(unicode: false),
                        Content = c.String(unicode: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tourquery");
        }
    }
}
