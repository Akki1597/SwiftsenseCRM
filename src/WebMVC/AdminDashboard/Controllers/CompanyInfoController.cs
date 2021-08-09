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

namespace AdminDashboard.Controllers
{
    
    public class CompanyInfoController : Controller
    {
        private readonly ICompanyInfo _companyInfosvc;
        public CompanyInfoController(ICompanyInfo companyInfo)
        {
            _companyInfosvc = companyInfo;
        }

        public async Task<IActionResult> Index(int? id)  /*int? page*/
        {
            //int itemsPage = 10;
            
           // var info = await  _companyInfosvc.GetCompanyInfo("sw751");
            var vm = new CompanyIndexViewModel()
            {
                //companyInfos = info,

                //paginationInfo = new PaginationInfo()
                //{
                //    actualPage = page??0,
                //    itemsPerPage= itemsPage,
                //    totalItems = info.count,
                //    totalpages = (int)Math.Ceiling(((decimal)info.count/itemsPage))
                //}
                
            };
            //vm.paginationInfo.next = (vm.paginationInfo.actualPage == vm.paginationInfo.totalpages - 1) ? "is-disabled" : "";
            //vm.paginationInfo.previous = (vm.paginationInfo.actualPage == 0) ? "is-disabled" : "";
            return View(vm);
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
