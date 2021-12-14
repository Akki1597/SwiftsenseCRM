using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class TimeSheetController : Controller
    {
        public IActionResult TimeSheet()
        {
            return View();
        }

        public IActionResult ViewTimeSheet()
        {
            return View();
        }

        public IActionResult ViewTimeSheetDemo()
        {
            return View();
        }
    }
}