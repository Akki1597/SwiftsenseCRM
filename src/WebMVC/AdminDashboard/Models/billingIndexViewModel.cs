using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class billingIndexViewModel
    {
        public billinginfo billinginfo { get; set; }

        
        public PaginationInfo paginationInfo { get; set; }
        public List<SelectListItem> yearList { get; set; }
        [Display(Name = "Year")]
        [Required(ErrorMessage = "Year is required.")]
        public string selectedYear { get; set; }
        [Display(Name = "Month")]
        [Required(ErrorMessage = "Month is required.")]
        public string selectedMonth { get; set; }
        public int clientId { get; set; }
        public List<SelectListItem> monthList { get; set; }
    }
}
