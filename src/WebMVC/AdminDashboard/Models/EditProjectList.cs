using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class EditProjectList
    {
        [Display(Name = "Project Id")]
        [Required(ErrorMessage = "Please enter your Project Id")]
        public string projectId { get; set; }
        public int id { get; set; }
        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "Please select client")]
        public int clientId { get; set; }
      
        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "Please enter your Project Name")]
        public string name { get; set; }

        [Display(Name = "Project Code")]
        [Required(ErrorMessage = "Please enter your Project Code")]
        public string pCode { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter Status")]
        public string status { get; set; }
        public List<SelectListItem> projectStatusList { get; set; }

        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }

        public List<SelectListItem> clientlist { get; set; }
    }
}
