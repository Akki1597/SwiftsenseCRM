using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class InvoiceDetails
    {
        public int? totalAmount { get; set; }
        public string invoiceNo { get; set; } 
        public string date { get; set; }
        public int? totalHours { get; set; }
        public string billingMonth { get; set; }
        public string projectName { get; set; }
        public string clientName { get; set; }
        public string projectId { get; set; }
    }
}
