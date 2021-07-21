using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class PaginationInfo
    {
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int actualPage { get; set; }
        public int totalpages { get; set; }
       public string  previous { get; set; }
        public string next { get; set; }

    }
}
