using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class InvoiceDetails
    {
        public int id { get; set; }
        public string invoiceNo { get; set; }
        public string billingMonth { get; set; }
        public string clientName { get; set; }
        public string projectName { get; set; }
        public string projectId { get; set; }
        public string totalHours { get; set; }
        public decimal totalAmount { get; set; }
    }
}
