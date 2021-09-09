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
        public ClientDetails client { get; set; }
        [Required(ErrorMessage = "Client is required.")]
        public List<SelectListItem> clientList { get; set; }
        [Required(ErrorMessage = "Please select your client.")]
        public List<SelectListItem> empClientList { get; set; }
        [Required(ErrorMessage = "Project is required.")]
        public ProjectDetails project { get; set; }
        public List<SelectListItem> projectList { get; set; }

        [Required(ErrorMessage = "Please select your project.")]
        public List<SelectListItem> empProjectList { get; set; }
        [Required(ErrorMessage = "Employee is required.")]
        public EmployeeTimeSheet employee { get; set; }
        public List<SelectListItem> employeeList { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public YearList year { get; set; }
        public List<SelectListItem> yearList { get; set; }

        [Required(ErrorMessage = "Month is required.")]
        public MonthList month { get; set; }
        public List<SelectListItem> monthList { get; set; }

    }
}
