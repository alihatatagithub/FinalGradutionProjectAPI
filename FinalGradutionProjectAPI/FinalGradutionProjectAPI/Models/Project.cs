using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public string JobTitleInThisProject { get; set; }
        public string ProjectDiscribtion { get; set; }

        [ForeignKey("CV")]
        public int CVID { get; set; }
        public CV CV { get; set; }
    }
}