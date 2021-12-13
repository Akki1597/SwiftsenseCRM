using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels
{
    public class ProfessionalDetails
    {
        [Required(ErrorMessage = "Please enter your Job title")]
        [Display(Name = "Job title")]
        public string jobTitle { get; set; }

        [Display(Name = "Company name")]
        [Required(ErrorMessage = "Please enter Company name")]
        public string companyName { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Responsibilities")]
        [Required(ErrorMessage = "Please enter Responsibilities")]
        public string responsibilities { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Please enter Comments")]
        public string comments { get; set; }

        [Required(ErrorMessage = "Please enter Start date")]
        [Display(Name = "Start date")]
        [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime startDate { get; set; }

        [Required(ErrorMessage = "Please enter End date")]
        [Display(Name = "End date")]
        [BindProperty, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public virtual DateTime endDate { get; set; }

        public string skill { get; set; }
        public string skill2 { get; set; }

    }
}
