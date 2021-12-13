using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class EducationalDetails
    {
        public CompanyIndexViewModel companydetails { get; set; } = new CompanyIndexViewModel();
        public ClientDetails clientDetails { get; set; } = new ClientDetails();
        public billingRate billingRate { get; set; } = new billingRate();
        public ProjectDetails projectDetails { get; set; } = new ProjectDetails();
        public int? totalAmount { get; set; } = 0;
        public string invoiceCount { get; set; }
        public string invoiceDate { get; set; }
        public int ? totalhrs {get;set;}
        public string billingMonth { get; set; }
    }
}
