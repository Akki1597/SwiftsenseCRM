using System.ComponentModel.DataAnnotations;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class ClientDetails
    {
        [Display(Name = "Category")]
        public int ClientId { get; set; }
    }
}