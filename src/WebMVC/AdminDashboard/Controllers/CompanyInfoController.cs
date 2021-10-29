using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;

namespace AdminDashboard.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CompanyInfoController : Controller
    {
        private readonly ICompanyInfo _companyInfosvc;
        public CompanyInfoController(ICompanyInfo companyInfo)
        {
            _companyInfosvc = companyInfo;
        }

        public async Task<IActionResult> Index(string id)  /*int? page*/
        {
            //int itemsPage = 10;

            var info = await _companyInfosvc.GetCompanyInfo("sw751");
            //var vm = new CompanyIndexViewModel()
            //{
              
                //paginationInfo = new PaginationInfo()
                //{
                //    actualPage = page??0,
                //    itemsPerPage= itemsPage,
                //    totalItems = info.count,
                //    totalpages = (int)Math.Ceiling(((decimal)info.count/itemsPage))
                //}

            //};
            //vm.paginationInfo.next = (vm.paginationInfo.actualPage == vm.paginationInfo.totalpages - 1) ? "is-disabled" : "";
            //vm.paginationInfo.previous = (vm.paginationInfo.actualPage == 0) ? "is-disabled" : "";
            return View(info);
        }

        public async Task<IActionResult> SaveCompanyDetails(CompanyIndexViewModel req)
        {
            try
            {
                var info = await _companyInfosvc.SetCompanyInfo(req);
                if (info)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("CRMDetails", "CRMDetails");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
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
