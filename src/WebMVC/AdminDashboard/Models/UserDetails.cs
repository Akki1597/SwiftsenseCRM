using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class UserDetails
    {
        public string id { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid User Id")]
        public string email { get; set; }
        //[Display(Name = "Mobile")]
        //[RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        //[Required(ErrorMessage = "Mobile Number is required.")]
        //public string mobile { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        public List<SelectListItem> roles { get; set; }
        [Display(Name = "Roles")]
        [Required(ErrorMessage = "Role is required")]
        public string roleId { get; set; }
        //[Display(Name = "Last Name")]
        //[Required(ErrorMessage = "Last Name is required.")]
        //public string lName { get; set; }

        //public List<SelectListItem> genderList { get; set; }
        //[Display(Name = "Gender")]
        //[Required(ErrorMessage = "Please select Gender")]
        //public string gender { get; set; }
    }
}
