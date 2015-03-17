namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TracksAndArtists : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        ArtistName = c.String(nullable: false, maxLength: 128),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtistName);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        TrackName = c.String(nullable: false, maxLength: 128),
                        ArtistName = c.String(nullable: false, maxLength: 128),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TrackName, t.ArtistName })
                .ForeignKey("dbo.Artists", t => t.ArtistName, cascadeDelete: true)
                .Index(t => t.ArtistName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "ArtistName", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "ArtistName" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Artists");
        }
    }
}
