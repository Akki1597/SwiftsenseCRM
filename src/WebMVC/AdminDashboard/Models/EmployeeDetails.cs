using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class EmployeeDetails
    {
        public int id { get; set; }
        [DisplayName("FirstName")]
        public string firstName { get; set; } 
        [DisplayName("LasttName")]
        public string lastName { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Mobile")]
        public string mobile { get; set; }
        [DisplayName("Address")]
        public string address { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime dob { get; set; }
        
        public string status { get; set; }
        public string projectId { get; set; }
        [DisplayName("Rate/hr")]
        public int? ratePerHr { get; set; }
        [DisplayName("Total Working Hrs")]
        public int? totalhr { get; set; }
    }
}
