using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class billinginfo
    {
        public int id { get; set; }
        public string companyId { get; set; }

        [Display(Name = "Company Name")]
        public string companyName { get; set; }

        [Display(Name = "Address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter your GST Number")]
        [Display(Name = "GST Number")]
        public string gstNo { get; set; }

        [Required(ErrorMessage = "Please enter your mobile number")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        [Display(Name = "Phone Number")]
        public string phoneNo { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }

        public BankDetails bankDetails { get; set; }

        public string xyz { get; set; }

    }
}
