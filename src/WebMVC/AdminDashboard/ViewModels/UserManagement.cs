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
        public string userId { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}
