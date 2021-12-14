using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.Models
{
    public class InvoiceDetails
    {
        [Key]
        public int id { get; set; }
        public int? totalAmount { get; set; }
        public string invoiceNo { get; set; } 
        public string date { get; set; }
        public int? totalHours { get; set; }
        public string billingMonth { get; set; }
        public string billingYear { get; set; }
        public string projectName { get; set; }
        public string clientName { get; set; }
        public string projectId { get; set; }
        public int clientId { get; set; }
        public string companyId { get; set; }
    }
}
