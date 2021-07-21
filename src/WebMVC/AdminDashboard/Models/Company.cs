using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class Company
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int count { get; set; }
        public List<CompanyInfo> data { get; set; }
    }
}
