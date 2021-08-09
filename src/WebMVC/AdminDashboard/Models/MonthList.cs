using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class MonthList
    {
        [Display(Name = "Month")]
        public int monthId { get; set; }
    }
}
