using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
        [Authorize]
        public IActionResult About()
        {
            return View();
        }
    }
}