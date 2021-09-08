using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class RatePerHourResponse
    {
        
        //public string selectedCurrency { get; set; }
        
        public string item_firstName { get; set; }
        
        public int item_ratePerHr { get; set; }
        
        public int item_totalhr { get; set; }
    }

}
