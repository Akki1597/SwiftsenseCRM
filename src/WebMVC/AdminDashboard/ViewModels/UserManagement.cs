using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class UserManagement
    {
        [Display(Name = "Type")]
        public int invoiceId { get; set; }
        public List<SelectListItem> employeeList { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid User Id")]
        public string email { get; set; }
        [Display(Name = "Mobile")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        public string mobile { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string fName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string lName { get; set; }
        [Display(Name = "Gender")]
        public List<SelectListItem> genderList { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        public string gender { get; set; }
    }
}
