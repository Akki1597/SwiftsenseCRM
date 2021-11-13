using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
   public interface IBillingInfo
    {
        Task<InvoiceDetails> GetInvoiceDetails(string invoiceNumber);
        Task<bool> SaveInvoiceDetails(InvoiceDetails invocieDetails);
        Task<int> GetInvoiceCount();
        Task<int> GetUnbilledHours();
        Task<string> GetInvoiceList(string id);
        Task<List<ResBillingRate>> GetBillingRate(string projectId);
    }
}
