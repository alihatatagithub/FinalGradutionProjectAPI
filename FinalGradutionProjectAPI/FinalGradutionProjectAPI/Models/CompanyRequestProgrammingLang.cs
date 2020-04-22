using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CompanyRequestProgrammingLang
    {
        [Key]
        [Column(Order = 1)]
        public string CRPLName { get; set; }
        public int CRPLExperience { get; set; }
        [Key]
        [Column(Order = 2)]
        [ForeignKey("CompanyRequest")]
        public int RequestId { get; set; }
        public CompanyRequest CompanyRequest { get; set; }
    }
}