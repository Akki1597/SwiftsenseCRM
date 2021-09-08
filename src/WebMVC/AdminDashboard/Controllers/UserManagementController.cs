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
                new SelectListItem {Text = "Select Type"},
                new SelectListItem {Text = "Employee", Value = "1"},
                new SelectListItem {Text = "Payroll", Value = "2"},
                new SelectListItem {Text = "Hr", Value = "3"},
                new SelectListItem {Text = "Admin", Value = "4"},

            };
            return View(model);
        }
        public IActionResult ViewUserType()
        {
            return View();
        }
        public IActionResult UserAccountType()
        {
            return View();
        }
        public IActionResult ViewUserToken()
        {
            return View();
        }
    }
}