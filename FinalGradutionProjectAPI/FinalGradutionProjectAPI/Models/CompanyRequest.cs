using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CompanyRequest
    {
        [Key]
        public int RequestId { get; set; }

        public string CompanyRequestJobTitle { get; set; }
        public string CompanyRequestJobRequirement { get; set; }
        public int CompanyRequestJobExperience { get; set; }

        public string ProgrammingLanguage { get; set; }
        [ForeignKey("CompanyHR")]
        public int CompanyHRID { get; set; }

        public CompanyHR CompanyHR { get; set; }
    }
}