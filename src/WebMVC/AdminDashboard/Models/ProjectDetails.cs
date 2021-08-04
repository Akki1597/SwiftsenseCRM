using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class ProjectDetails
    {
        [Display(Name = "Client")]
        public int projectId { get; set; }
    }
}
