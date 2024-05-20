namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecializationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Doctors", "SpecializationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Doctors", "SpecializationId");
            AddForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations", "Id", cascadeDelete: true);
            DropColumn("dbo.Doctors", "Major");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Doctors", "Major", c => c.String());
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropColumn("dbo.Doctors", "SpecializationId");
            DropTable("dbo.Specializations");
        }
    }
}
