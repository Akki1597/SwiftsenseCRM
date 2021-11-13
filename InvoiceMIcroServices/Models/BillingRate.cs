using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class BillingRate
    {
        [Key]
        public int id { get; set; }
        public string employeeName { get; set; }
        public int? noofHours { get; set; }
        public int? rateperHr { get; set; } 
        public string projectId { get; set; }
    }

    public class billingRate
    {
        public List<SelectListItem> CurrencyType { get; set; }
        [DisplayName("Currency Type")]
        [Required(ErrorMessage = "Please Select Currency Type")]
        public string selectedCurrency { get; set; }
        public List<EmployeeDetail> Employees { get; set; } = new List<EmployeeDetail>();
    }

    public class EmployeeDetail
    {
        [DisplayName("Employee Name")]
        public string employeeName { get; set; }
        [DisplayName("Total Number of Hours")]
        public int? NoofHours { get; set; }
        [DisplayName("Rate/hr")]
        [Required(ErrorMessage = "Rate/Hr is required")]
        public int? RatePerHr { get; set; }
    }
}
