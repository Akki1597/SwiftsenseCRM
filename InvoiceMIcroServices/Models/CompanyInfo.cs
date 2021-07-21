using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class CompanyInfo
    {
        [Key]
        public int id { get; set; }
        public string companyId { get; set; } 
        public string companyName { get; set; }
        public string address { get; set; }
        public string gstNo { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
    }
}
