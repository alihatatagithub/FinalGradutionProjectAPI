using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CVDataBase
    {
        [ForeignKey("CV")]
        [Key]
        [Column(Order = 1)]
        public int CVID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CVDataBaseName { get; set; }
        public int CVDataBaseExperience { get; set; }

        public CV CV { get; set; }
    }
}