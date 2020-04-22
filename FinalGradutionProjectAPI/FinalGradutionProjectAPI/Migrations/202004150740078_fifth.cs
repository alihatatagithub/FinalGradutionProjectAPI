namespace FinalGradutionProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVProgrammingLangs",
                c => new
                    {
                        CVID = c.Int(nullable: false),
                        CVProgrammingLangName = c.String(nullable: false, maxLength: 128),
                        CVProgrammingLangExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CVID, t.CVProgrammingLangName })
                .ForeignKey("dbo.CVs", t => t.CVID, cascadeDelete: true)
                .Index(t => t.CVID);
            
            CreateTable(
                "dbo.CVTechnologies",
                c => new
                    {
                        CVID = c.Int(nullable: false),
                        CVTechnologiesName = c.String(nullable: false, maxLength: 128),
                        CVTechnologiesExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CVID, t.CVTechnologiesName })
                .ForeignKey("dbo.CVs", t => t.CVID, cascadeDelete: true)
                .Index(t => t.CVID);
            
            CreateTable(
                "dbo.CVWorkHistories",
                c => new
                    {
                        CVID = c.Int(nullable: false),
                        CVWorkHistoryCompanyName = c.String(nullable: false, maxLength: 128),
                        CVWorkHistoryJobTitle = c.String(),
                        CVWorkHistoryDuration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CVID, t.CVWorkHistoryCompanyName })
                .ForeignKey("dbo.CVs", t => t.CVID, cascadeDelete: true)
                .Index(t => t.CVID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CVWorkHistories", "CVID", "dbo.CVs");
            DropForeignKey("dbo.CVTechnologies", "CVID", "dbo.CVs");
            DropForeignKey("dbo.CVProgrammingLangs", "CVID", "dbo.CVs");
            DropIndex("dbo.CVWorkHistories", new[] { "CVID" });
            DropIndex("dbo.CVTechnologies", new[] { "CVID" });
            DropIndex("dbo.CVProgrammingLangs", new[] { "CVID" });
            DropTable("dbo.CVWorkHistories");
            DropTable("dbo.CVTechnologies");
            DropTable("dbo.CVProgrammingLangs");
        }
    }
}
