namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAndTimeSetAsSeparatePropertiesInAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("_dbo.Appointments", "Date", c => c.DateTime(nullable: false));
            AddColumn("_dbo.Appointments", "Time", c => c.DateTime(nullable: false));
            DropColumn("_dbo.Appointments", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("_dbo.Appointments", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("_dbo.Appointments", "Time");
            DropColumn("_dbo.Appointments", "Date");
        }
    }
}
