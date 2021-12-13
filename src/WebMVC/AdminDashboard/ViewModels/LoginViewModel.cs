using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class LoginViewModel
    {
        //public string userName { get; set; }
        [Display(Name = "Email")]
        //[RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        [EmailAddress]
        public string email { get; set; }
        [Display(Name = "Password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,15}$", ErrorMessage = "Please enter minimum 6 characters including at least one uppercase letter, one lowercase letter, one number, and one special symbol")]
        public string password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } = false;
    }
}
