namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateMigrationsAsInterimStepWasInvalidInSql2014 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        ArtistName = c.String(),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistId);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackId = c.String(nullable: false, maxLength: 128),
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        TrackName = c.String(),
                        ArtistName = c.String(),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackId, t.ArtistId })
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Artists");
        }
    }
}
