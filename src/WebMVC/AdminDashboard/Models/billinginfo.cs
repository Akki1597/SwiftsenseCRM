using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class billinginfo
    {
       public CompanyIndexViewModel companydetails { get; set; }
       public ClientDetails clientDetails { get; set; }
       public billingRate billingRate { get; set; }
       public ProjectDetails projectDetails { get; set; }
       public int? totalAmount { get; set; }
    
    }
}
