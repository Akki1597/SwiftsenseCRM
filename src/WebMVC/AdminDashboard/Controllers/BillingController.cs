using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult Billing()
        {
            BillingInvoice model = new BillingInvoice();
            model.invoiceList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Invoice--", Value = "1"},
                new SelectListItem {Text = "demo", Value = "2"},
                new SelectListItem {Text = "demo1", Value = "3"}
            };
            return View(model);
        }
        public IActionResult Generateinvoice()
        {
            return View();
        }
        public IActionResult ViewInvoiceList()
        {
            return View();
        }
    }
}