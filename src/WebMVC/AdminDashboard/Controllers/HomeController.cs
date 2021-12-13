using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientInfo _clientInfosvc;
        private readonly IProjectInfo _projectInfosvc;
        private readonly ICompanyInfo _companyInfosvc;
        private readonly IBillingInfo _billingInfo;
        private readonly IEmployee _employeesvc;
        private readonly IDelete _deletesvc;

        public HomeController(IClientInfo clientInfo, IProjectInfo projectInfo, IEmployee employee, ICompanyInfo companyInfo, IBillingInfo billingInfo,IDelete delete)
        {
            _clientInfosvc = clientInfo;
            _projectInfosvc = projectInfo;
            _employeesvc = employee;
            _billingInfo = billingInfo;
            _companyInfosvc = companyInfo;
            _deletesvc = delete;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult About()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<string> Delete(string id)
        {
            var res = await _deletesvc.deleteItem(id);
            return res.ToString();
        }
    }
}