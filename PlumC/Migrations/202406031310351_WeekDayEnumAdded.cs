namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeekDayEnumAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DoctorOfficeAvailabilities", "DayOfWeek", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DoctorOfficeAvailabilities", "DayOfWeek", c => c.String());
        }
    }
}
