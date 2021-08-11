using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class ProjectDetails
    {
        [Display(Name = "Client")]
        public int projectId { get; set; }

        [Display(Name = "Project Name")]
        public string projectname { get; set; }
        [Display(Name = "Project Code")]
        [Required(ErrorMessage = "Please enter your Project Code")]
        public string projectcode { get; set; }
        [Display(Name = "Project Id")]
        [Required(ErrorMessage = "Please enter your Project Id")]
        public int proId { get; set; }
        [Display(Name = "Project State")]
        [Required(ErrorMessage = "Please enter your Project State")]
        public string projectState { get; set; }
        [Display(Name = "Project Type")]
        [Required(ErrorMessage = "Please enter your Project Type")]
        public string projectType { get; set; }
        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }
    }
}
