using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels
{
    public class SalaryDetails
    {
        [Display(Name = "Basic")]
        [Required(ErrorMessage = "Please enter your Basic salary")]
        public string basic { get; set; }

        [Display(Name = "Travel Allowance")]
        [Required(ErrorMessage = "Please enter Travel Allavance")]
        public string travelAllowance { get; set; }

        [Display(Name = "ESI Deduction")]
        [Required(ErrorMessage = "Please enter ESI Deduction")]
        public string esiDeduction { get; set; }

        [Display(Name = "PF Employee Share")]
        [Required(ErrorMessage = "Please enter PF Employee Share")]
        public string pfEmployee { get; set; }

        [Display(Name = "Net In-Hand Salary")]
        [Required(ErrorMessage = "Please enter your Net In-Hand Salary")]
        public string netInHandSalary { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Please enter Comments")]
        public string comments { get; set; }

        [Required(ErrorMessage = "Please Select Month")]
        [Display(Name = "Select Month")]
        [BindProperty, DataType("month"), DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public DateTime month { get; set; }
    }
}
