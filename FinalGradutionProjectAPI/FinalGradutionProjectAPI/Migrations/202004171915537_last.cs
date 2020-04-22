namespace FinalGradutionProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 128),
                        CompanyName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.AspNetUsers", t => t.CompanyID)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        JobSeekerId = c.String(nullable: false, maxLength: 128),
                        JobSeekerName = c.String(),
                    })
                .PrimaryKey(t => t.JobSeekerId)
                .ForeignKey("dbo.AspNetUsers", t => t.JobSeekerId)
                .Index(t => t.JobSeekerId);
            
            AddColumn("dbo.CompanyHRs", "Company_CompanyID", c => c.String(maxLength: 128));
            AddColumn("dbo.CompanyRequests", "Company_CompanyID", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "JobSeeker_JobSeekerId", c => c.String(maxLength: 128));
            AddColumn("dbo.CVWorkHistories", "JobSeeker_JobSeekerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CompanyHRs", "Company_CompanyID");
            CreateIndex("dbo.CompanyRequests", "Company_CompanyID");
            CreateIndex("dbo.Projects", "JobSeeker_JobSeekerId");
            CreateIndex("dbo.CVWorkHistories", "JobSeeker_JobSeekerId");
            AddForeignKey("dbo.CompanyHRs", "Company_CompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.CompanyRequests", "Company_CompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.CVWorkHistories", "JobSeeker_JobSeekerId", "dbo.JobSeekers", "JobSeekerId");
            AddForeignKey("dbo.Projects", "JobSeeker_JobSeekerId", "dbo.JobSeekers", "JobSeekerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "JobSeeker_JobSeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.CVWorkHistories", "JobSeeker_JobSeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.JobSeekers", "JobSeekerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CompanyRequests", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.CompanyHRs", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompanyID", "dbo.AspNetUsers");
            DropIndex("dbo.JobSeekers", new[] { "JobSeekerId" });
            DropIndex("dbo.CVWorkHistories", new[] { "JobSeeker_JobSeekerId" });
            DropIndex("dbo.Projects", new[] { "JobSeeker_JobSeekerId" });
            DropIndex("dbo.CompanyRequests", new[] { "Company_CompanyID" });
            DropIndex("dbo.CompanyHRs", new[] { "Company_CompanyID" });
            DropIndex("dbo.Companies", new[] { "CompanyID" });
            DropColumn("dbo.CVWorkHistories", "JobSeeker_JobSeekerId");
            DropColumn("dbo.Projects", "JobSeeker_JobSeekerId");
            DropColumn("dbo.CompanyRequests", "Company_CompanyID");
            DropColumn("dbo.CompanyHRs", "Company_CompanyID");
            DropTable("dbo.JobSeekers");
            DropTable("dbo.Companies");
        }
    }
}
