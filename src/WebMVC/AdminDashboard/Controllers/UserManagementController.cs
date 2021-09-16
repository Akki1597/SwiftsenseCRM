using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class UserManagementController : Controller
    {
        public IActionResult UserManagement()
        {
            UserManagement model = new UserManagement();
            model.employeeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Type",Value=""},
                new SelectListItem {Text = "Employee", Value = "1"},
                //new SelectListItem {Text = "Payroll", Value = "2"},
                //new SelectListItem {Text = "Hr", Value = "3"},
                //new SelectListItem {Text = "Admin", Value = "4"},

            };
            model.genderList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Gender",Value=""},
                new SelectListItem {Text = "Male", Value = "1"},
                new SelectListItem {Text = "Female", Value = "2"},
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult ViewUserType()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserAccountType()
        {
            UserManagement model = new UserManagement();
            model.genderList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Gender"},
                new SelectListItem {Text = "Male", Value = "1"},
                new SelectListItem {Text = "Female", Value = "2"},
            };
            return View(model);
        }
        public IActionResult ViewUserToken()
        {
            return View();
        }
    }
}