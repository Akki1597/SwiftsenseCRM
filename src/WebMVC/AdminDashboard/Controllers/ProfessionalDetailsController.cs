using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class ProfessionalDetailsController : Controller
    {
        public IActionResult ProfessionalDetails()
        {
            return View();
        }

        public IActionResult AddNewProfessionalDetails()
        {
            return View();
        }
    }
}