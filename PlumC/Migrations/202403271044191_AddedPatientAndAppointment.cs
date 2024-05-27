namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPatientAndAppointment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "_dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("_dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("_dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
            CreateTable(
                "_dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("_dbo.Appointments", "PatientId", "_dbo.Patients");
            DropForeignKey("_dbo.Appointments", "DoctorId", "_dbo.Doctors");
            DropIndex("_dbo.Appointments", new[] { "PatientId" });
            DropIndex("_dbo.Appointments", new[] { "DoctorId" });
            DropTable("_dbo.Patients");
            DropTable("_dbo.Appointments");
        }
    }
}
