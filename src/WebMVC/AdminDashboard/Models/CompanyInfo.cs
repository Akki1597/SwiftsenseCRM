using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class CompanyInfo
    {
        public int id { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string gstNo { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public BankDetails bankDetails { get; set; }
       
    }
}
