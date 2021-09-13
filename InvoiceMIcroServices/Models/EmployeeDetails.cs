using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public DateTime dob { get; set; }
        public string status { get; set; }
        public string projectId { get; set; }
        public int totalhr { get; set; }
        public int ratePerHr { get; set; }

    }
}
