using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class billingRate
    {
        [DisplayName("Employee Name")]
        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }
        [DisplayName("Rate/hr")]
        [Required(ErrorMessage = "Rate/hr is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only accept numbers")]
        public string RatePerHr { get; set; }
        [DisplayName("Currency Type")]
        public List<SelectListItem> CurrencyType { get; set; }
        [DisplayName("Total Number of Hours")]
        [Required(ErrorMessage = "Number of Hours is required")]
        public string NoofHours { get; set; }
    }
}
