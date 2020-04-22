namespace FinalGradutionProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVEductions",
                c => new
                    {
                        CVID = c.Int(nullable: false),
                        UniversityName = c.String(nullable: false, maxLength: 128),
                        Major = c.String(),
                        FacultyName = c.String(),
                        Languages = c.String(),
                    })
                .PrimaryKey(t => new { t.CVID, t.UniversityName })
                .ForeignKey("dbo.CVs", t => t.CVID, cascadeDelete: true)
                .Index(t => t.CVID);
            
            CreateTable(
                "dbo.CVGeneralConcepts",
                c => new
                    {
                        CVID = c.Int(nullable: false),
                        CVGeneralConcepts = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CVID, t.CVGeneralConcepts })
                .ForeignKey("dbo.CVs", t => t.CVID, cascadeDelete: true)
                .Index(t => t.CVID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CVGeneralConcepts", "CVID", "dbo.CVs");
            DropForeignKey("dbo.CVEductions", "CVID", "dbo.CVs");
            DropIndex("dbo.CVGeneralConcepts", new[] { "CVID" });
            DropIndex("dbo.CVEductions", new[] { "CVID" });
            DropTable("dbo.CVGeneralConcepts");
            DropTable("dbo.CVEductions");
        }
    }
}
