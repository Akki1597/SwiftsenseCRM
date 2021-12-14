using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PersonalDetails()
        {
            PersonalDetails model = new PersonalDetails();
            model.genderList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Gender",Value=""},
                new SelectListItem {Text = "Female", Value = "1"},
                new SelectListItem {Text = "Male", Value = "2"},
            };
            return View(model);

        }

        public IActionResult ProfessionalDetails()
        {
            return View();
        }

        public IActionResult AddNewProfessionalDetails()
        {
            return View();
        }

        public IActionResult SalaryDetails()
        {
            return View();
        }

        public IActionResult EducationalDetails()
        {
            EducationalDetails model = new EducationalDetails();
            model.typeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Level",Value=""},
                new SelectListItem {Text = "Graduation", Value = "1"},
            };
            model.levelList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Type",Value=""},
                new SelectListItem {Text = "B.sc", Value = "1"},
            };
            model.streamList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Stream",Value=""},
                new SelectListItem {Text = "Electronics", Value = "1"},
                new SelectListItem {Text = "Computer Science", Value = "2"},
                new SelectListItem {Text = "Electrical", Value = "3"},
                new SelectListItem {Text = "Mechanical", Value = "4"},
                new SelectListItem {Text = "AutoMobile", Value = "5"},
                new SelectListItem {Text = "Civil", Value = "6"},
            };
            model.instituteList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Institute",Value=""},
                new SelectListItem {Text = "IHRD", Value = "1"},
            };
            model.statusList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Status",Value=""},
                new SelectListItem {Text = "Compeleted", Value = "1"},
                new SelectListItem {Text = "Ongoing", Value = "2"},

            };
            return View(model);
        }
        public IActionResult AddNewEducationalDetails()
        {
            AddEducationalDetails model = new AddEducationalDetails();
            model.typeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Level",Value=""},
                new SelectListItem {Text = "Graduation", Value = "1"},
            };
            model.levelList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Type",Value=""},
                new SelectListItem {Text = "B.sc", Value = "1"},
            };
            model.streamList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Stream",Value=""},
                new SelectListItem {Text = "Electronics", Value = "1"},
                new SelectListItem {Text = "Computer Science", Value = "2"},
                new SelectListItem {Text = "Electrical", Value = "3"},
                new SelectListItem {Text = "Mechanical", Value = "4"},
                new SelectListItem {Text = "AutoMobile", Value = "5"},
                new SelectListItem {Text = "Civil", Value = "6"},
            };
            model.instituteList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Institute",Value=""},
                new SelectListItem {Text = "IHRD", Value = "1"},
            };
            model.statusList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Status",Value=""},
                new SelectListItem {Text = "Compeleted", Value = "1"},
                new SelectListItem {Text = "Ongoing", Value = "2"},

            };
            return View(model);
        }

        public IActionResult BankDetails()
        {
            return View();
        }
        public IActionResult AddNewBankDetails()
        {
            return View();
        }
    }
}