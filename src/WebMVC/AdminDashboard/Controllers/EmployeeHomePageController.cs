using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class EmployeeHomePageController : Controller
    {
        public IActionResult EmployeeHomePage()
        {
            return View();
        }
    }
}