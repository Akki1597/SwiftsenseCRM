using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
   public interface IBillingInfo
    {
        Task<bool> SaveInvoiceDetails(InvoiceDetails invocieDetails);
        Task<int> GetInvoiceCount();
        Task<string> GetInvoiceList(string id);
    }
}
