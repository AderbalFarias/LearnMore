using System.Data.Entity.Migrations;

namespace LearnMore.Mvc.Persistence.Migrations
{
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                {
                    EventId = c.Int(nullable: false),
                    AttendeeId = c.String(nullable: false, maxLength: 128),
                    Event_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.EventId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.AttendeeId)
                .Index(t => t.Event_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "Event_Id" });
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropTable("dbo.Attendances");
        }
    }
}
