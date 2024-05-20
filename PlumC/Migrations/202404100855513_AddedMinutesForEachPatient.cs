namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMinutesForEachPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "MinutesForEachPatient", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "MinutesForEachPatient");
        }
    }
}
