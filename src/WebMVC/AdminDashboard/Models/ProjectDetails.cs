using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Required(ErrorMessage = "Please enter Project Id")]
        public string projectId { get; set; }
        public int id { get; set; }
        //[Display(Name = "Client Name")]
        //[Required(ErrorMessage = "Please select Client")]
        public int clientId { get; set; }
        //public List<SelectListItem> client { get; set; }
        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Please enter  Project Name")]
        public string name { get; set; }
        [Display(Name = "Project Code")]
        [Required(ErrorMessage = "Please enter  Project Code")]
        public string pCode { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is reqiured")]
        public string status { get; set; }
        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }

    }
}
