using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels
{
    public class PersonalDetails
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "First Name")]
        public string fName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please enter your Last Name")]
        public string lName { get; set; }

        [Display(Name = "Gender")]
        public List<SelectListItem> genderList { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        public string gender { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your Address")]
        public string address { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter your Phone Number")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your Email Address")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string email { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Please enter your State")]
        public string state { get; set; }

        [Required(ErrorMessage = "Please enter your Date of Birth")]
        [Display(Name = "DOB")]
        public string dob { get; set; }

        [Display(Name = "Mother Tongue")]
        [Required(ErrorMessage = "Please enter your Mother Tongue")]
        public string motherTongue { get; set; }

        [Display(Name = "Emergency Contact Number")]
        [Required(ErrorMessage = "Please enter your Alternate Phone Number")]
        [RegularExpression(@"\d{10}", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string alternatePhone { get; set; }

        [Display(Name = "Upload Resume")]
        [Required(ErrorMessage = "Please upload your resume")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\+\@\#\$\%\^\&\*\'\,\`\(\)\{\}:])+(.doc|.docx|.pdf)$", ErrorMessage = "Allowed file types are .doc,.docx, and .pdf")]
        [DataType(DataType.Upload)]
        public string resume { get; set; }

        [Display(Name = "PAN")]
        [Required(ErrorMessage = "Please upload your PAN")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\+\@\#\$\%\^\&\*\'\,\`\(\)\{\}:])+(.doc|.docx|.pdf)$", ErrorMessage = "Allowed file types are .doc,.docx, and .pdf")]
        [DataType(DataType.Upload)]
        public string pan { get; set; }

        [Display(Name = "Aadhaar")]
        [Required(ErrorMessage = "Please upload your Aadhaar")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\+\@\#\$\%\^\&\*\'\,\`\(\)\{\}:])+(.doc|.docx|.pdf)$", ErrorMessage = "Allowed file types are .doc,.docx, and .pdf")]
        [DataType(DataType.Upload)]
        public string aadhaar { get; set; }

        [Display(Name = "Passport")]
        [Required(ErrorMessage = "Please upload your Passport")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-\+\@\#\$\%\^\&\*\'\,\`\(\)\{\}:])+(.doc|.docx|.pdf)$", ErrorMessage = "Allowed file types are .doc,.docx, and .pdf")]
        [DataType(DataType.Upload)]
        public string passport { get; set; }

    }
}
