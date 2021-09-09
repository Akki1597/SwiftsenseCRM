using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class BankDetails
    {
        [Required(ErrorMessage = "Please enter your Bank Details")]
        [Display(Name = "Name as per bank details")]
        public string name { get; set; }

        [Display(Name = "Account Number")]
        [Required(ErrorMessage = "Please enter your Account Number")]
        public string accountNumber { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Please enter your Bank Name")]
        public string bankName { get; set; }

        [Display(Name = "Swift Code")]
        [Required(ErrorMessage = "Please enter your Swift Code")]
        public string swiftCode { get; set; }

    }
}
