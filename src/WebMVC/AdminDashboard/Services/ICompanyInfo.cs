using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
   public interface ICompanyInfo
    {
        Task<CompanyInfo> GetCompanyInfo(string id);
    }
}
