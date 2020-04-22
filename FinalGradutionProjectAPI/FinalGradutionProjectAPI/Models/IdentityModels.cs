using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace FinalGradutionProjectAPI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [ForeignKey("ApplicationRole")]
        [Display(Name = "UserType")]
        public string RoleId { get; set; }

        public ApplicationRole ApplicationRole { get; set; }
    }

    public class Company 
    {
        public List<CompanyHR> CompanyHRs { get; set; }
        public List<CompanyRequest> CompanyRequests { get; set; }
        public string CompanyName { get; set; }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string CompanyID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }

    public class JobSeeker
    {
        public List<Project> Projects { get; set; }
        public List<CVWorkHistory> CVWorkHistories { get; set; }
        public string JobSeekerName { get; set; }
        [Key]
        [ForeignKey("ApplicationUser")]
        public string JobSeekerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
    public class ApplicationRole:IdentityRole
    {

    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CV> CVs { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CVDataBase> CVDataBases { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CVEduction> CVEductions { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CVGeneralConcept> CVGeneralConcepts { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CVProgrammingLang> CVProgrammingLangs { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CVTechnology> CVTechnologies { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CVWorkHistory> CVWorkHistories { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CompanyHR> CompanyHRs { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CompanyRequest> CompanyRequests { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CompanyRequestDataBase> CompanyRequestDataBases { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CompanyRequestGeneralConcept> CompanyRequestGeneralConcepts { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CompanyRequestProgrammingLang> CompanyRequestProgrammingLangs { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.CompanyRequestTechnology> CompanyRequestTechnologies { get; set; }

        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.ApplicationRole> IdentityRoles { get; set; }
        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.JobSeeker> JobSeekers { get; set; }
        public System.Data.Entity.DbSet<FinalGradutionProjectAPI.Models.Company> Companies { get; set; }


    }
}