namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartAndEndDateToAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "TimeStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "TimeEnd", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "TimeEnd");
            DropColumn("dbo.Appointments", "TimeStart");
        }
    }
}
