using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class CompanyDetails
    {
        public int id { get; set; }
        public string companyId { get; set; }
        public string companyName { get; set; }
        public string address { get; set; }
        public string gstNo { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string swiftCode { get; set; }
    }
}
