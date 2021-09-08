using System.ComponentModel.DataAnnotations;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class ClientDetails
    {
        
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your Address")]
        public string address { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter your Phone")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your Email")]
        public string email { get; set; }
        [Display(Name = "Project")]
        [Required(ErrorMessage = "Please enter your Project")]
        public string project { get; set; }
        [Display(Name = "Number of unbilled hours")]
        [Required(ErrorMessage = "Please enter your No.of unbilled hours")]
        public string unbilledHours { get; set; }
        public string status { get; set; }
        public string projectId { get; set; }
    }
}