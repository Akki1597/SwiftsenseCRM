using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class CrmIndexViewModel
    {
        [Required(ErrorMessage = "Client is required.")]
        public int clientId { get; set; }
        public List<SelectListItem> clientStatusList { get; set; }
        [Required(ErrorMessage = "Please select your client.")]
        public List<SelectListItem> empClientList { get; set; }
        [Required(ErrorMessage = "Please enter your Project Id")]
        public string projectId { get; set; }
        [Required(ErrorMessage = "Please select Project Status")]
        public string selectedPstatus { get; set; }
        [Required(ErrorMessage = "Please select Client Status")]
        public string selectedCstatus { get; set; }

        public List<SelectListItem> projectStatusList { get; set; }
        [Required(ErrorMessage = "Please select your project.")]
        public List<SelectListItem> empProjectList { get; set; }
        [Required(ErrorMessage = "Employee is required.")]
        [Display(Name = "Employee")]
        public int employeeId { get; set; }
        public List<SelectListItem> employeeList { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        [Display(Name = "Year")]
        public int yearId { get; set; }
        public List<SelectListItem> yearList { get; set; }
        [Display(Name = "Month")]
        [Required(ErrorMessage = "Month is required.")]
        public int monthId { get; set; }
        public List<SelectListItem> monthList { get; set; }

    }
}
