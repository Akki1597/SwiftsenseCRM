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

        [Display(Name = "projectWise")]
        public int projectWise { get; set; }
        public List<SelectListItem> invoiceListProjectWise { get; set; }

        [Display(Name = "clientWise")]
        public int clientWise { get; set; }
        public List<SelectListItem> invoiceListClientWise { get; set; }

        [Display(Name = "monthWise")]
        public int monthWise { get; set; }
        public List<SelectListItem> invoiceListMonthWise { get; set; }

        [Display(Name = "yearWise")]
        public int yearWise { get; set; }
        public List<SelectListItem> invoiceListYearWise { get; set; }
    }
}
