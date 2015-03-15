namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtistAndTrackIds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tracks", "ArtistName", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "ArtistName" });
            DropPrimaryKey("dbo.Artists");
            DropPrimaryKey("dbo.Tracks");
            AddColumn("dbo.Artists", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tracks", "TrackId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Tracks", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Artists", "ArtistName", c => c.String());
            AlterColumn("dbo.Tracks", "TrackName", c => c.String());
            AlterColumn("dbo.Tracks", "ArtistName", c => c.String());
            AddPrimaryKey("dbo.Artists", "ArtistId");
            AddPrimaryKey("dbo.Tracks", new[] { "TrackId", "ArtistId" });
            CreateIndex("dbo.Tracks", "ArtistId");
            AddForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists", "ArtistId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "ArtistId", "dbo.Artists");
            DropIndex("dbo.Tracks", new[] { "ArtistId" });
            DropPrimaryKey("dbo.Tracks");
            DropPrimaryKey("dbo.Artists");
            AlterColumn("dbo.Tracks", "ArtistName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tracks", "TrackName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Artists", "ArtistName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Tracks", "ArtistId");
            DropColumn("dbo.Tracks", "TrackId");
            DropColumn("dbo.Artists", "ArtistId");
            AddPrimaryKey("dbo.Tracks", new[] { "TrackName", "ArtistName" });
            AddPrimaryKey("dbo.Artists", "ArtistName");
            CreateIndex("dbo.Tracks", "ArtistName");
            AddForeignKey("dbo.Tracks", "ArtistName", "dbo.Artists", "ArtistName", cascadeDelete: true);
        }
    }
}
