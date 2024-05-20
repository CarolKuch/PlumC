namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAndTimeSetAsSeparatePropertiesInAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "Time");
            DropColumn("dbo.Appointments", "Date");
        }
    }
}
