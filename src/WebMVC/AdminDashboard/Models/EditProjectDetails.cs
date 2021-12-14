using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class EditProjectDetails
    {
        [Display(Name = "Project Id")]
        [Required(ErrorMessage = "Please enter your Project Id")]
        public string projectId { get; set; }
        public int clientId { get; set; }
        [Display(Name = "Client")]
        [Required(ErrorMessage = "Please select Client Name")]
        public string client { get; set; }
        public List<SelectListItem> clientList { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Please enter your Project Name")]
        public string name { get; set; }
        [Display(Name = "Project Code")]
        [Required(ErrorMessage = "Please enter your Project Code")]
        public string pCode { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is reqiured")]
        public string status { get; set; }
        public List<SelectListItem> statusList { get; set; }
    }
}
