namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAddedToDoctorOfficeAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DoctorOfficeAvailabilities", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorOfficeAvailabilities", "Date");
        }
    }
}
