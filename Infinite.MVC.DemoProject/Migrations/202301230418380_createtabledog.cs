namespace Infinite.MVC.DemoProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtabledog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BreedName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetName = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        BreedsId = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Breeds", t => t.BreedsId, cascadeDelete: true)
                .Index(t => t.BreedsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "BreedsId", "dbo.Breeds");
            DropIndex("dbo.Pets", new[] { "BreedsId" });
            DropTable("dbo.Pets");
            DropTable("dbo.Breeds");
        }
    }
}
