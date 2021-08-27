using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class billingIndexViewModel
    {
        public billinginfo companyInfos { get; set; }

        
        public PaginationInfo paginationInfo { get; set; }
        public List<SelectListItem> yearList { get; set; }
        public List<SelectListItem> monthList { get; set; }
    }
}
