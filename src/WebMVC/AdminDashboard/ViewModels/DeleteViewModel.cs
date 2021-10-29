using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class DeleteViewModel
    {
        public int clientId { get; set; }
        public string projectId { get; set; }
        public string id { get; set; }
    }
}
