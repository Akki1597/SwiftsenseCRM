using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.EmpModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class PersonalDetailsController : Controller
    {
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
    }
}