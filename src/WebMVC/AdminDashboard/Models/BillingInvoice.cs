using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class BillingInvoice
    {
        [Display(Name = "Invoice")]
        public int invoice { get; set; }
        public List<SelectListItem> invoiceList { get; set; }
    }
}
