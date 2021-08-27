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
        public string CurrencyType { get; set; }
    }
}
