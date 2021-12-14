using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class BankDetailsController : Controller
    {
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