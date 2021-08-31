using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class billingRate
    {
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }
        [DisplayName("Rate/hr")]
        public string RatePerHr { get; set; }
        [DisplayName("Currency Type")]
        public List<SelectListItem> CurrencyType { get; set; }
        [DisplayName("Total Number of Hours")]
        public string NoofHours { get; set; }
    }
}
