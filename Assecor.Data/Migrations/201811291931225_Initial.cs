namespace Assecor.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lastname = c.String(),
                        Zipcode = c.String(),
                        City = c.String(),
                        ColorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colors", t => t.ColorId)
                .Index(t => t.ColorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "ColorId", "dbo.Colors");
            DropIndex("dbo.People", new[] { "ColorId" });
            DropTable("dbo.People");
            DropTable("dbo.Colors");
        }
    }
}
