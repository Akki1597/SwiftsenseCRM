using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class ProjectDetails
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string pCode { get; set; }
        public int clientId { get; set; }
        public string status { get; set; }
        public string unbilledHours { get; set; }
    }
}
