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

        [Display(Name = "User Id")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid User Id")]
        public string userId { get; set; }
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,15}$", ErrorMessage = "Please enter minimum 8 characters including at least one uppercase letter, one lowercase letter, one number, and one special symbol")]
        [Required(ErrorMessage = "Password is required.")]
        public string password { get; set; }
    }
}
