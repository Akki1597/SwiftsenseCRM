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
                new SelectListItem {Text = "--Select Employee--", Value = "1"},
                new SelectListItem {Text = "demo1", Value = "2"},
                new SelectListItem {Text = "Demo2", Value = "3"}
            };
          
            return View(model);
        }
    }
}