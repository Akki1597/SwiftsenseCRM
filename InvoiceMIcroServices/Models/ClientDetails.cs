using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class ClientDetails
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public int? projectId { get; set; }
        public string unbilledHours { get; set; }
    }
}
