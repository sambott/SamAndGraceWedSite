namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rsvps", "RsvpdAt", c => c.DateTime(nullable: false, defaultValue: DateTime.UtcNow));
            Configuration.DropDefaultConstraint("dbo.Rsvps", "RsvpdAt", q => Sql(q));
            AddColumn("dbo.Rsvps", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rsvps", "Email");
            DropColumn("dbo.Rsvps", "RsvpdAt");
        }
    }
}
