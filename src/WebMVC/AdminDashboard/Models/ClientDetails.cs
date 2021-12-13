using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class ClientDetails
    {
        
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter your Name")]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your Address")]
        public string address { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Please enter your Country Code")]
        [RegularExpression(@"/(\+\d{1,3})/", ErrorMessage = "Please enter your Country Code")]
        public string countryCode { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter your Phone Number")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string phoneNo { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }

        ////[Display(Name = "Project")]
        ////[Required(ErrorMessage = "Please enter your Project")]
        //public List<SelectListItem> project { get; set; }

        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }
        public string status { get; set; }
        //[Display(Name = "Project")]
        //[Required(ErrorMessage = "Please enter your Project")]
        public string projectId { get; set; }
    }
}