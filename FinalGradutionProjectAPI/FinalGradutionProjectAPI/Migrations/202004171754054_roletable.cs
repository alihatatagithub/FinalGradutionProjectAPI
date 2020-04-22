namespace FinalGradutionProjectAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roletable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "RoleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "RoleId");
            AddForeignKey("dbo.AspNetUsers", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "RoleId" });
            DropColumn("dbo.AspNetUsers", "RoleId");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetRoles", "Discriminator");
        }
    }
}
