using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Script.Serialization;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AdminDashboard.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BillingController : Controller
    {
        private readonly IClientInfo _clientInfosvc;
        private readonly IProjectInfo _projectInfosvc;
        private readonly ICompanyInfo _companyInfosvc;
        private readonly IBillingInfo _billingInfo;
        private readonly IEmployee _employeesvc;
        public BillingController(IClientInfo clientInfo, IProjectInfo projectInfo, IEmployee employee, ICompanyInfo companyInfo, IBillingInfo billingInfo)
        {
            _clientInfosvc = clientInfo;
            _projectInfosvc = projectInfo;
            _employeesvc = employee;
            _billingInfo = billingInfo;
            _companyInfosvc = companyInfo;
        }
        public async Task<IActionResult> Billing()
        {
            BillingInvoice model = new BillingInvoice();
            model.invoiceList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Invoice Filter", Value = ""},
                new SelectListItem {Text = "Project Wise", Value = "1"},
                new SelectListItem {Text = "Client Wise", Value = "2"},
                //new SelectListItem {Text = "Month Wise", Value = "3"},
                //new SelectListItem {Text = "Year Wise", Value = "4"},
            };

            List<ClientDetails> clist = await GetCLientlist();
            model.unbilledHours = await _billingInfo.GetUnbilledHours();
            model.invoiceListClientWise = new List<SelectListItem>();
            model.invoiceListClientWise.Add(new SelectListItem { Text = "Select Client Name", Value = "", Selected = true });
            for (int i = 0; i < clist.Count; i++)
            {
                model.invoiceListClientWise.Add(new SelectListItem { Text = clist[i].name, Value = clist[i].id.ToString() });
            }

            List<ProjectDetails> plist = await _projectInfosvc.Getprojectlist("1");

            model.invoiceListProjectWise = new List<SelectListItem>();
            model.invoiceListProjectWise.Add(new SelectListItem { Text = "Select Project Name", Value = "", Selected = true });
            for (int i = 0; i < plist.Count; i++)
            {
                model.invoiceListProjectWise.Add(new SelectListItem { Text = plist[i].name, Value = plist[i].projectId.ToString() });
            }
            model.invoiceListMonthWise = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Month",Value=""},
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
                 new SelectListItem {Text = "Select Year", Value = ""},
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

        public IActionResult ViewInvoiceList(string response)
        {
            List<InvoiceDetails> invoicelist = new List<InvoiceDetails>();
            invoicelist = JsonConvert.DeserializeObject<List<InvoiceDetails>>(response);
            return View(invoicelist);
        }

        public async Task<string> GetInvoiceList(string id)
        {
            var res = await _billingInfo.GetInvoiceList(id);
            return res;
        }
        public IActionResult billingmonth(string projectId)
        {
            billingIndexViewModel model = new billingIndexViewModel();
            //model.clientId = clientId;
            model.projectId = projectId;
            model.yearList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Year",Value=""},
                new SelectListItem {Text = "2021", Value = "2021"},
                new SelectListItem {Text = "2022", Value = "2022"},
                new SelectListItem {Text = "2023", Value = "2023"},
                new SelectListItem {Text = "2024", Value = "2024"},
                new SelectListItem {Text = "2025", Value = "2025"},
                new SelectListItem {Text = "2026", Value = "2026"},
                new SelectListItem {Text = "2027", Value = "2027"},
                new SelectListItem {Text = "2028", Value = "2028"},
                new SelectListItem {Text = "2029", Value = "2029"},
                new SelectListItem {Text = "2030", Value = "2030"}

            };
            model.monthList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Month",Value=""},
                new SelectListItem {Text = "January", Value = "January"},
                new SelectListItem {Text = "February", Value = "February"},
                new SelectListItem {Text = "March", Value = "March"},
                new SelectListItem {Text = "April", Value = "April"},
                new SelectListItem {Text = "May", Value = "May"},
                new SelectListItem {Text = "June", Value = "June"},
                new SelectListItem {Text = "July", Value = "July"},
                new SelectListItem {Text = "August", Value = "August"},
                new SelectListItem {Text = "September", Value = "September"},
                new SelectListItem {Text = "October", Value = "October"},
                new SelectListItem {Text = "November", Value = "November"},
                new SelectListItem {Text = "December", Value = "December"}
            };
            return View(model);
        }


        public IActionResult Selectedbillingmonth(billingIndexViewModel req)
        {

            TempData["selectedMonth"] = req.selectedMonth;
            TempData["selectedYear"] = req.selectedYear;
            TempData["projectId"] = req.projectId;
            
            return RedirectToAction("Rateperhr");
        }

        public async Task<IActionResult> Rateperhr()
        {
            var projectId = TempData["projectId"];

            billingRate model = new billingRate();

            model.CurrencyType = new List<SelectListItem>()
            {
                new SelectListItem {Text = "Currency Type",Value=""},
                new SelectListItem {Text = "USD", Value = "1",Selected = true},

            };

            //var cdetails = await GetClientDetails(Convert.ToInt32(clientId));

            var selectedMonth = TempData["selectedMonth"].ToString();
            var selectedYear = TempData["selectedYear"].ToString();

            TempData.Keep();

            var res = await GetEmplist(projectId.ToString());
            model.Employees = new List<EmployeeDetail>();
            foreach (var item in res)
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
            return RedirectToAction("InvoicePreview", "Billing");
        }

        public async Task<ActionResult> InvoicePreview()
        {
            billinginfo model = new billinginfo();

            model.billingMonth = TempData["selectedMonth"].ToString();
            model.billingYear = TempData["selectedYear"].ToString();
            model.invoiceCount = await GetLastInvoiceNo();

            if (TempData["billingrate"] is string s)
            {
                model.billingRate = JsonConvert.DeserializeObject<billingRate>(s);
            }
            var projectId = TempData["projectId"];
            TempData.Keep();

            HttpContext.Session.SetString("CompanyId", "sw751");
            var companyId = HttpContext.Session.GetString("CompanyId");
            model.companydetails = await GetCompanyDetails(companyId);
            model.projectDetails = await GetProjectDetails(projectId.ToString());
            model.clientDetails = await GetClientDetails(model.projectDetails.clientId);
            return View(model);
        }

        public async Task<IActionResult> ViewInvoice(string invoiceNumber)
        {
            billinginfo model = new billinginfo();
            var res = await _billingInfo.GetInvoiceDetails(invoiceNumber);
            model.invoiceCount = res.invoiceNo;
            model.invoiceDate = res.date;
            model.totalhrs = res.totalHours;
            model.totalAmount = res.totalAmount;

            model.companydetails = await GetCompanyDetails(res.companyId);
            model.projectDetails = await GetProjectDetails(res.projectId);
            var rate = await GetBillingRate(res.projectId);
           
            for(int i=0;i<rate.Count;i++)
            {
                EmployeeDetail employeeDetail = new EmployeeDetail()
                {
                    employeeName = rate[i].employeeName,
                    NoofHours = rate[i].NoofHours,
                    RatePerHr = rate[i].RatePerHr
                };
                model.billingRate.Employees.Add(employeeDetail);
            }
            model.clientDetails = await GetClientDetails(res.clientId);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> InvoicePreview(EducationalDetails req)
        {
            InvoiceDetails invoice = new InvoiceDetails()
            {
                invoiceNo = req.invoiceCount,
                date = req.invoiceDate,
                billingMonth = req.billingMonth,
                billingYear = req.billingYear,
                clientName = req.clientDetails.name,
                projectId = req.projectDetails.projectId,
                projectName = req.projectDetails.name,
                totalAmount = req.totalAmount,
                totalHours = req.totalhrs,
                clientId = req.clientDetails.id,
                companyId = req.companydetails.companyId,
                billingRate = (TempData["billingrate"] is string s) ? JsonConvert.DeserializeObject<billingRate>(s) : null,
            
            };

            var res = await _billingInfo.SaveInvoiceDetails(invoice);

            if (res == true)
            {
                return RedirectToAction("Billing");
            }
            else
            {
                return RedirectToAction("Rateperhr");
            }

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

    public async Task<List<ResBillingRate>> GetBillingRate(string projectId)
    {
        var info = await _billingInfo.GetBillingRate(projectId);
        return info;

    }

    public async Task<ProjectDetails> GetProjectDetails(string pId)
    {
    var info = await _projectInfosvc.GetProjectInfo(pId);
    return info;

    }


    public async Task<List<ClientDetails>> GetCLientlist()
    {
    var res = await _clientInfosvc.Getclientlist("1");
    return res;

    }
    public async Task<string> GetLastInvoiceNo()
    {
    var res = await _billingInfo.GetInvoiceCount();
    return res.ToString();
    }
    }
}