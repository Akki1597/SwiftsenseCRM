using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class ProjectDetails
    {
        [Display(Name = "Project Id")]
        [Required(ErrorMessage = "Please enter your Project Id")]
        public int projectId { get; set; }

        public int clientId { get; set; }

        [Required(ErrorMessage = "Please enter your Project Name")]
        [Display(Name = "Project Name")]
        public string name { get; set; }

        [Display(Name = "Project Code")]
        [Required(ErrorMessage = "Please enter your Project Code")]
        public string pCode { get; set; }

        [Required(ErrorMessage = "Please enter your Status")]
        public string status { get; set; }
        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }

    }
}
