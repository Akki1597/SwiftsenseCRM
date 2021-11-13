using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels
{
    public class AddBankDetails
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

        [Display(Name = "IFSC")]
        [Required(ErrorMessage = "Please enter IFSC")]
        public string ifsc { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Please enter Comments")]
        public string comments { get; set; }
    }
}
