namespace ClcWorld.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableaudit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityName = c.String(),
                        EntityIdentifier = c.String(maxLength: 100),
                        Action = c.String(maxLength: 20),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audits");
        }
    }
}
