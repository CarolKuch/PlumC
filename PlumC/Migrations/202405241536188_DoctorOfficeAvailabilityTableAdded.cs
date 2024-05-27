namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorOfficeAvailabilityTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "_dbo.DoctorOfficeAvailabilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        DayOfWeek = c.String(),
                        TimeStart = c.DateTime(nullable: false),
                        TimeEnd = c.DateTime(nullable: false),
                        IsDoctorAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("_dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("_dbo.Offices", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("_dbo.DoctorOfficeAvailabilities", "OfficeId", "_dbo.Offices");
            DropForeignKey("_dbo.DoctorOfficeAvailabilities", "DoctorId", "_dbo.Doctors");
            DropIndex("_dbo.DoctorOfficeAvailabilities", new[] { "DoctorId" });
            DropIndex("_dbo.DoctorOfficeAvailabilities", new[] { "OfficeId" });
            DropTable("_dbo.DoctorOfficeAvailabilities");
        }
    }
}
