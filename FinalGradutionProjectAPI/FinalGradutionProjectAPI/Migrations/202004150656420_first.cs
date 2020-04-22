namespace FinalGradutionProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CVDataBases",
                c => new
                    {
                        CVID = c.Int(nullable: false),
                        CVDataBaseName = c.String(nullable: false, maxLength: 128),
                        CVDataBaseExperience = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CVID, t.CVDataBaseName })
                .ForeignKey("dbo.CVs", t => t.CVID, cascadeDelete: true)
                .Index(t => t.CVID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CVDataBases", "CVID", "dbo.CVs");
            DropIndex("dbo.CVDataBases", new[] { "CVID" });
            DropTable("dbo.CVDataBases");
        }
    }
}
