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
        [Required(ErrorMessage ="Please Select UserType")]
        [Display(Name = "User Type")]
        public int userTypeId { get; set; }
        public List<SelectListItem> usertypeList { get; set; }
        [Required(ErrorMessage = "Please Type RoleName")]
        [Display(Name = "Role Name")]
        public string name { get; set; }

    }
}
