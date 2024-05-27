namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfficeTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "_dbo.Offices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomNumber = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        MinutesForPatient = c.Int(nullable: false),
                        FirstConsultationFee = c.Int(nullable: false),
                        FollowUpConsultationFee = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("_dbo.Offices");
        }
    }
}
