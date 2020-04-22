using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CompanyRequestGeneralConcept
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("CompanyRequest")]
        public int RequestId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string GeneralConcept { get; set; }

        public CompanyRequest CompanyRequest { get; set; }
    }
}