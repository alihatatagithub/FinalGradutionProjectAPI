using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CVEduction
    {
        [ForeignKey("CV")]
        [Key]
        [Column(Order = 1)]
        public int CVID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string UniversityName { get; set; }
        public string Major { get; set; }
        public string FacultyName { get; set; }
        public string Languages { get; set; }
        public CV CV { get; set; }
    }
}