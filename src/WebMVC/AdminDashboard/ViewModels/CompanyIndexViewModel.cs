using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class CompanyIndexViewModel
    {
        public CompanyInfo companyInfos { get; set; }
        
        public PaginationInfo paginationInfo { get; set; }
    }
}
