using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels
{
    public class EducationalDetails 
    {
        [Display(Name = "Level")]
        [Required(ErrorMessage = "Please select Level")]
        public string level { get; set; }
        public List<SelectListItem> levelList { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please select Type")]
        public string type { get; set; }
        public List<SelectListItem> typeList { get; set; }

        [Display(Name = "Stream")]
        [Required(ErrorMessage = "Please select Stream")]
        public string stream { get; set; }
        public List<SelectListItem> streamList { get; set; }

        [Display(Name = "Institute")]
        [Required(ErrorMessage = "Please select Institute")]
        public string institute { get; set; }
        public List<SelectListItem> instituteList { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please select Status")]
        public string status { get; set; }
        public List<SelectListItem> statusList { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Please enter Comments")]
        public string comments { get; set; }
    }
}
