using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalGradutionProjectAPI.Models
{
    public class CV
    {
        [Key]
        public int CVID { get; set; }
        public string Objective { get; set; }
        public string Technologies { get; set; }
        public List<Project> Projects { get; set; }
    }
}