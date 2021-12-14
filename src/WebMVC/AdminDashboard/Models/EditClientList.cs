using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class EditClientList
    {
        public int clientId { get; set; }
        public string projectId { get; set; }
        [Required(ErrorMessage = "Please enter Client Name")]
        [Display(Name = "Client Name")]
        public string clientName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your Address")]
        public string address { get; set; }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Please enter your Country Code")]
        [RegularExpression(@"/^(\+?\d{1,3}|\d{1,4})$/", ErrorMessage = "Please enter your Country Code")]
        public string countryCode { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter your phone")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please enter Status")]
        public string status { get; set; }
        public List<SelectListItem> clientStatusList{ get; set; }

        //[Display(Name = "Project")]
        //[Required(ErrorMessage = "Please enter your Project")]
        //public string project { get; set; }

        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }
    }
}
