using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CompanyRequestDataBase
    {
        [ForeignKey("CompanyRequest")]
        [Key]
        [Column(Order = 1)]
        public int RequestId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CompanyRequestDataBaseName { get; set; }
        public int CompanyRequestDataBaseExperience { get; set; }

        public CompanyRequest CompanyRequest { get; set; }
    }
}