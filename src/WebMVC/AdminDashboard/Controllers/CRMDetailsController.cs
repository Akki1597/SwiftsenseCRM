using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class CRMDetailsController : Controller
    {
        public IActionResult CRMDetails()
        {
            Common model = new Common();
            model.clientList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Category--", Value = "1"},
                new SelectListItem {Text = "demo1", Value = "2"},
                new SelectListItem {Text = "demo2", Value = "3"}
            };
            model.projectList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Client--", Value = "1"},
                new SelectListItem {Text = "demo3", Value = "2"},
                new SelectListItem {Text = "demo4", Value = "3"}
            };

            model.employeeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Employee--", Value = "1"},
                new SelectListItem {Text = "demo5", Value = "2"},
                new SelectListItem {Text = "demo6", Value = "3"}
            };

            return View(model);
        }
    }
}