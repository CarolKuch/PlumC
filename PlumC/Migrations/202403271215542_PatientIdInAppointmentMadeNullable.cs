namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientIdInAppointmentMadeNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("_dbo.Appointments", "PatientId", "_dbo.Patients");
            DropIndex("_dbo.Appointments", new[] { "PatientId" });
            AlterColumn("_dbo.Appointments", "PatientId", c => c.Int());
            CreateIndex("_dbo.Appointments", "PatientId");
            AddForeignKey("_dbo.Appointments", "PatientId", "_dbo.Patients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("_dbo.Appointments", "PatientId", "_dbo.Patients");
            DropIndex("_dbo.Appointments", new[] { "PatientId" });
            AlterColumn("_dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            CreateIndex("_dbo.Appointments", "PatientId");
            AddForeignKey("_dbo.Appointments", "PatientId", "_dbo.Patients", "Id", cascadeDelete: true);
        }
    }
}
