using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CVWorkHistory
    {
        [ForeignKey("CV")]
        [Key]
        [Column(Order = 1)]
        public int CVID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string CVWorkHistoryCompanyName { get; set; }
        public string CVWorkHistoryJobTitle { get; set; }
        public int CVWorkHistoryDuration { get; set; }

        public CV CV { get; set; }
    }
}