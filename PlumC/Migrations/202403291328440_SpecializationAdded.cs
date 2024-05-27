namespace PlumC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecializationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "_dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("_dbo.Doctors", "SpecializationId", c => c.Int(nullable: false));
            CreateIndex("_dbo.Doctors", "SpecializationId");
            AddForeignKey("_dbo.Doctors", "SpecializationId", "_dbo.Specializations", "Id", cascadeDelete: true);
            DropColumn("_dbo.Doctors", "Major");
        }
        
        public override void Down()
        {
            AddColumn("_dbo.Doctors", "Major", c => c.String());
            DropForeignKey("_dbo.Doctors", "SpecializationId", "_dbo.Specializations");
            DropIndex("_dbo.Doctors", new[] { "SpecializationId" });
            DropColumn("_dbo.Doctors", "SpecializationId");
            DropTable("_dbo.Specializations");
        }
    }
}
