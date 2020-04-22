using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CompanyHR
    {
        [Key]
        public int CompanyHRID { get; set; }
        public string CompanyHRName { get; set; }
    }
}