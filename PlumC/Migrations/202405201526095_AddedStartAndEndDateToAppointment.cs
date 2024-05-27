namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStartAndEndDateToAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("_dbo.Appointments", "TimeStart", c => c.DateTime(nullable: false));
            AddColumn("_dbo.Appointments", "TimeEnd", c => c.DateTime(nullable: false));
            DropColumn("_dbo.Appointments", "Time");
        }
        
        public override void Down()
        {
            AddColumn("_dbo.Appointments", "Time", c => c.DateTime(nullable: false));
            DropColumn("_dbo.Appointments", "TimeEnd");
            DropColumn("_dbo.Appointments", "TimeStart");
        }
    }
}
