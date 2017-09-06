namespace ClcWorld.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Registration = c.String(),
                        FranchiseeId = c.Int(nullable: false),
                        CarBrandId = c.Int(nullable: false),
                        Kilometers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBrands", t => t.CarBrandId, cascadeDelete: true)
                .ForeignKey("dbo.Franchisees", t => t.FranchiseeId, cascadeDelete: true)
                .Index(t => t.FranchiseeId)
                .Index(t => t.CarBrandId);
            
            CreateTable(
                "dbo.Franchisees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "FranchiseeId", "dbo.Franchisees");
            DropForeignKey("dbo.Cars", "CarBrandId", "dbo.CarBrands");
            DropIndex("dbo.Cars", new[] { "CarBrandId" });
            DropIndex("dbo.Cars", new[] { "FranchiseeId" });
            DropTable("dbo.Franchisees");
            DropTable("dbo.Cars");
            DropTable("dbo.CarBrands");
        }
    }
}
