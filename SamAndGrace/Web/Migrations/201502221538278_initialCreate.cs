namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
// ReSharper disable once InconsistentNaming
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rsvps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Attending = c.Boolean(nullable: false),
                        RequiresTransport = c.Boolean(nullable: false),
                        DietryRequirements = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rsvps");
        }
    }
}
