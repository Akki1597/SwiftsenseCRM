using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class BankDetails
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string accountNumber { get; set; }
        public string bankName { get; set; }
        public string companyId { get; set; }
        public string swiftCode { get; set; }
    }
}
