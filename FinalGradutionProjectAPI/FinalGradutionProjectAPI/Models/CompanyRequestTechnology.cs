using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CompanyRequestTechnology
    {
        [ForeignKey("CompanyRequest")]
        [Key]
        [Column(Order = 1)]
        public int RequestId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CompanyRequestTecnologiesName { get; set; }
        public int CompanyRequestTecnologiesExperience { get; set; }


        public CompanyRequest CompanyRequest { get; set; }
    }
}