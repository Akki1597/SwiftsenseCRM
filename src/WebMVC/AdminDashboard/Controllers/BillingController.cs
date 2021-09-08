using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AdminDashboard.Controllers
{
    public class BillingController : Controller
    {
        private readonly IClientInfo _clientInfosvc;
        private readonly IProjectInfo _projectInfosvc;
        private readonly ICompanyInfo _companyInfosvc;
        private readonly IEmployee _employeesvc;
        public BillingController(IClientInfo clientInfo, IProjectInfo projectInfo, IEmployee employee,ICompanyInfo companyInfo)
        {
            _clientInfosvc = clientInfo;
            _projectInfosvc = projectInfo;
            _employeesvc = employee;
            _companyInfosvc = companyInfo;
        }
        public IActionResult Billing()
        {
            BillingInvoice model = new BillingInvoice();
            model.invoiceList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Invoice Filter", Value = "0"},
                new SelectListItem {Text = "Project Wise", Value = "1"},
                new SelectListItem {Text = "Client Wise", Value = "2"},
                new SelectListItem {Text = "Month Wise", Value = "3"},
                new SelectListItem {Text = "Year Wise", Value = "4"},
            };
            model.invoiceListClientWise = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Client Name", Value = "0"},
            };
            model.invoiceListProjectWise = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Project Name", Value = "0"},
            };
            model.invoiceListMonthWise = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Month",Value="0"},
                new SelectListItem {Text = "January", Value = "1"},
                new SelectListItem {Text = "February", Value = "2"},
                new SelectListItem {Text = "March", Value = "3"},
                new SelectListItem {Text = "April", Value = "4"},
                new SelectListItem {Text = "May", Value = "5"},
                new SelectListItem {Text = "June", Value = "6"},
                new SelectListItem {Text = "July", Value = "7"},
                new SelectListItem {Text = "August", Value = "8"},
                new SelectListItem {Text = "September", Value = "9"},
                new SelectListItem {Text = "October", Value = "10"},
                new SelectListItem {Text = "November", Value = "11"},
                new SelectListItem {Text = "December", Value = "12"}
            };
            model.invoiceListYearWise = new List<SelectListItem>
            {
                 new SelectListItem {Text = "Select Year", Value = "0"},
                new SelectListItem {Text = "2020-21", Value = "1"},
                new SelectListItem {Text = "2021-22", Value = "2"},
                new SelectListItem {Text = "2022-23", Value = "3"},
                new SelectListItem {Text = "2023-24", Value = "4"},
                new SelectListItem {Text = "2024-25", Value = "5"},
                new SelectListItem {Text = "2025-26", Value = "6"},
                new SelectListItem {Text = "2026-27", Value = "7"},
                new SelectListItem {Text = "2027-28", Value = "8"},
                new SelectListItem {Text = "2028-29", Value = "9"},
                new SelectListItem {Text = "2029-30", Value = "10"},
                new SelectListItem {Text = "2030-31", Value = "11"}
            };
            return View(model);
        }
        public async Task<IActionResult> Generateinvoice()
        {
            var res = await _projectInfosvc.Getprojectlist("1");
            //List<ProjectDetails> res = new List<ProjectDetails>();
            return View(res);
        }
        public IActionResult ViewInvoiceList()
        {

            return View();
        }
        public IActionResult billingmonth(int clientId)
        {
            billingIndexViewModel model = new billingIndexViewModel();
            model.clientId = clientId;
            model.yearList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Year"},
                new SelectListItem {Text = "2020", Value = "1"},
                new SelectListItem {Text = "2021", Value = "2"},
                new SelectListItem {Text = "2022", Value = "3"},
                new SelectListItem {Text = "2023", Value = "4"},
                new SelectListItem {Text = "2024", Value = "5"},
                new SelectListItem {Text = "2025", Value = "6"},
                new SelectListItem {Text = "2026", Value = "7"},
                new SelectListItem {Text = "2027", Value = "8"},
                new SelectListItem {Text = "2028", Value = "9"},
                new SelectListItem {Text = "2029", Value = "10"},
                new SelectListItem {Text = "2030", Value = "11"}

            };
            model.monthList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Month"},
                new SelectListItem {Text = "January", Value = "2"},
                new SelectListItem {Text = "February", Value = "3"},
                new SelectListItem {Text = "March", Value = "4"},
                new SelectListItem {Text = "April", Value = "5"},
                new SelectListItem {Text = "May", Value = "6"},
                new SelectListItem {Text = "June", Value = "7"},
                new SelectListItem {Text = "July", Value = "8"},
                new SelectListItem {Text = "August", Value = "9"},
                new SelectListItem {Text = "September", Value = "10"},
                new SelectListItem {Text = "October", Value = "11"},
                new SelectListItem {Text = "November", Value = "12"},
                new SelectListItem {Text = "December", Value = "13"}
            };
            return View(model);
        }

        
        public IActionResult Selectedbillingmonth(billingIndexViewModel req)
        {
            
            TempData["selectedMonth"] = req.selectedMonth;
            TempData["selectedYear"] = req.selectedYear;
            TempData["clientId"] = req.clientId;

            return RedirectToAction("Rateperhr");
        }

        public async Task<IActionResult> Rateperhr()
        {
            var clientId = TempData["clientId"];
       
            billingRate model = new billingRate();

            model.CurrencyType = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Currency Type"},
                new SelectListItem {Text = "USD", Value = "1"},

                };
            var cdetails =  await GetClientDetails(Convert.ToInt32(clientId));

            var selectedMonth = TempData["selectedMonth"].ToString();
            var selectedYear = TempData["selectedYear"].ToString();


            TempData.Keep();

            var res  = await GetEmplist(cdetails.projectId);
            model.Employees = new List<EmployeeDetail>();
            foreach(var item in res)
            {
                EmployeeDetail rate = new EmployeeDetail();
                rate.employeeName = item.firstName + item.lastName;
                rate.NoofHours = item.totalhr;
                rate.RatePerHr = item.ratePerHr;

                model.Employees.Add(rate);
            }
            return View(model);
        }
        //public async Task<IActionResult> BillingRate()
        //{
        //    List<EmployeeDetails> model = new List<EmployeeDetails>();


        //    var selectedMonth = TempData["selectedMonth"].ToString();
        //    var selectedYear = TempData["selectedYear"].ToString();

      
        //    TempData.Keep();
        //    model =  await GetEmplist("P000SW1");

        //    //model.ratePerHr = new List<RatePerHourResponse>();

        //    //foreach (var item in model.Employees)
        //    //{
        //    //    RatePerHourResponse billingmodel = new RatePerHourResponse();
        //    //    billingmodel.employeeName = item.firstName + " " + item.lastName;
        //    //    billingmodel.NoofHours = item.totalhr;
        //    //    billingmodel.RatePerHr = 0;
        //    //    billingmodel.selectedCurrency = "";

        //    //    model.ratePerHr.Add(billingmodel);
        //    //}

        ////model.Employees =  await GetEmplist("P000SW1",selectedYear,selectedMonth);
        //        return View(model);
        //}

        [HttpPost]
        public IActionResult Rateperhr(billingRate item)
        {
            var s = JsonConvert.SerializeObject(item);
            TempData["billingrate"] = s;
            TempData.Keep();
            return RedirectToAction("InvoicePreview","Billing");
        }

        public async Task<ActionResult> InvoicePreview()
        {
            billinginfo model = new billinginfo();

            if (TempData["billingrate"] is string s)
            {
                model.billingRate = JsonConvert.DeserializeObject<billingRate>(s);
            }
            var clientId = TempData["clientId"];
            TempData.Keep();
            model.clientDetails = await GetClientDetails(Convert.ToInt32(clientId));
             HttpContext.Session.SetString("CompanyId", "sw751");
            var companyId = HttpContext.Session.GetString("CompanyId");
            model.companydetails = await GetCompanyDetails(companyId);
            model.projectDetails = await GetProjectDetails(model.clientDetails.projectId);
            return View(model);
        }

        public async Task<List<EmployeeDetails>> GetEmplist(string pId)
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails = await _employeesvc.GetEmplistDetails(pId);
            return employeeDetails;

        }

        public async Task<CompanyIndexViewModel> GetCompanyDetails(string companyId)
        {
            var info = await _companyInfosvc.GetCompanyInfo(companyId);
            return info;

        }

        public async Task<ClientDetails> GetClientDetails(int? clinetId)
        {
            var info = await _clientInfosvc.GetClientInfo(clinetId);
            return info;

        }

        public async Task<ProjectDetails> GetProjectDetails(string pId)
        {
            var info = await _projectInfosvc.GetProjectInfo(pId);
            return info;

        }
    }
}