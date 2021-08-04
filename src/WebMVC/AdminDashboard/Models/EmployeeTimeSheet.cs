using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class EmployeeTimeSheet
    {
        [Display(Name = "Client")]
        public int projectClient { get; set; }
        [Display(Name = "Project")]
        public int empProject { get; set; }
        [Display(Name = "Employee")]
        public int employeeId { get; set; }
        [Required(ErrorMessage = "Please enter Year")]
        [Display(Name = "Year")]
        public int year { get; set; }
        [Required(ErrorMessage = "Please enter Month")]
        [Display(Name = "Month")]
        public string month { get; set; }
    }
}
