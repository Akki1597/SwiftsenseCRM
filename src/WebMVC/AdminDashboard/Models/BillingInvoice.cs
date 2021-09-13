﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Required(ErrorMessage = "Please select Invoice")]
        public string invoice { get; set; }
        public List<SelectListItem> invoiceList { get; set; }

        [Display(Name = "projectWise")]
        [Required(ErrorMessage = "Please select Project Name")]
        public string projectWise { get; set; }
        public List<SelectListItem> invoiceListProjectWise { get; set; }

        [Display(Name = "clientWise")]
        [Required(ErrorMessage = "Please select Client Name")]
        public string clientWise { get; set; }
        public List<SelectListItem> invoiceListClientWise { get; set; }

        [Display(Name = "monthWise")]
        [Required(ErrorMessage = "Please select Month")]
        public string monthWise { get; set; }
        public List<SelectListItem> invoiceListMonthWise { get; set; }

        [Display(Name = "yearWise")]
        [Required(ErrorMessage = "Please select Year")]
        public string yearWise { get; set; }
        public List<SelectListItem> invoiceListYearWise { get; set; }
    }
}
