using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;

namespace AdminDashboard.Controllers
{
    public class CompanyInfoController : Controller
    {
        private readonly ICompanyInfo _companyInfosvc;
        public CompanyInfoController(ICompanyInfo companyInfo)
        {
            _companyInfosvc = companyInfo;
        }

        public async Task<IActionResult> Index()
        {
            var info = await _companyInfosvc.GetCompanyInfo();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
