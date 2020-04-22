namespace FinalGradutionProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyHRs",
                c => new
                    {
                        CompanyHRID = c.Int(nullable: false, identity: true),
                        CompanyHRName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyHRID);
            
            CreateTable(
                "dbo.CompanyRequestDataBases",
                c => new
                    {
                        RequestId = c.Int(nullable: false),
                        CompanyRequestDataBaseName = c.String(nullable: false, maxLength: 128),
                        CompanyRequestDataBaseExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequestId, t.CompanyRequestDataBaseName })
                .ForeignKey("dbo.CompanyRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.CompanyRequests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        CompanyRequestJobTitle = c.String(),
                        CompanyRequestJobRequirement = c.String(),
                        CompanyRequestJobExperience = c.Int(nullable: false),
                        ProgrammingLanguage = c.String(),
                        CompanyHRID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.CompanyHRs", t => t.CompanyHRID, cascadeDelete: true)
                .Index(t => t.CompanyHRID);
            
            CreateTable(
                "dbo.CompanyRequestGeneralConcepts",
                c => new
                    {
                        RequestId = c.Int(nullable: false),
                        GeneralConcept = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RequestId, t.GeneralConcept })
                .ForeignKey("dbo.CompanyRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.CompanyRequestProgrammingLangs",
                c => new
                    {
                        CRPLName = c.String(nullable: false, maxLength: 128),
                        RequestId = c.Int(nullable: false),
                        CRPLExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CRPLName, t.RequestId })
                .ForeignKey("dbo.CompanyRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
            CreateTable(
                "dbo.CompanyRequestTechnologies",
                c => new
                    {
                        RequestId = c.Int(nullable: false),
                        CompanyRequestTecnologiesName = c.String(nullable: false, maxLength: 128),
                        CompanyRequestTecnologiesExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequestId, t.CompanyRequestTecnologiesName })
                .ForeignKey("dbo.CompanyRequests", t => t.RequestId, cascadeDelete: true)
                .Index(t => t.RequestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompanyRequestTechnologies", "RequestId", "dbo.CompanyRequests");
            DropForeignKey("dbo.CompanyRequestProgrammingLangs", "RequestId", "dbo.CompanyRequests");
            DropForeignKey("dbo.CompanyRequestGeneralConcepts", "RequestId", "dbo.CompanyRequests");
            DropForeignKey("dbo.CompanyRequestDataBases", "RequestId", "dbo.CompanyRequests");
            DropForeignKey("dbo.CompanyRequests", "CompanyHRID", "dbo.CompanyHRs");
            DropIndex("dbo.CompanyRequestTechnologies", new[] { "RequestId" });
            DropIndex("dbo.CompanyRequestProgrammingLangs", new[] { "RequestId" });
            DropIndex("dbo.CompanyRequestGeneralConcepts", new[] { "RequestId" });
            DropIndex("dbo.CompanyRequests", new[] { "CompanyHRID" });
            DropIndex("dbo.CompanyRequestDataBases", new[] { "RequestId" });
            DropTable("dbo.CompanyRequestTechnologies");
            DropTable("dbo.CompanyRequestProgrammingLangs");
            DropTable("dbo.CompanyRequestGeneralConcepts");
            DropTable("dbo.CompanyRequests");
            DropTable("dbo.CompanyRequestDataBases");
            DropTable("dbo.CompanyHRs");
        }
    }
}
