using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Models
{
    public class ProjectInfo
    {
        [Key]
        public int id { get; set; }
        public string projectname { get; set; }
        public string projectcode { get; set; }
        public string proId { get; set; }
        public string projectState { get; set; }
        public string projectType { get; set; }
        public string unbilledHours { get; set; }
    }
}
