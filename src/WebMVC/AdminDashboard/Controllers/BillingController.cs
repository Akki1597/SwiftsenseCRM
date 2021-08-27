using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class BillingController : Controller
    {
        private readonly IClientInfo _clientInfosvc;
        private readonly IProjectInfo _projectInfosvc;
        private readonly IEmployee _employeesvc;
        public BillingController(IClientInfo clientInfo, IProjectInfo projectInfo, IEmployee employee)
        {
            _clientInfosvc = clientInfo;
            _projectInfosvc = projectInfo;
            _employeesvc = employee;
        }
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
        public async Task<IActionResult> Generateinvoice()
        {
            var res = await _projectInfosvc.Getprojectlist("1");

            return View(res);
        }
        public IActionResult ViewInvoiceList()
        {

            return View();
        }
    }
}