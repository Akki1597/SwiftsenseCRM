using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    public class CRMDetailsController : Controller
    {
        private readonly IClientInfo _clientInfosvc;
        private readonly IProjectInfo _projectInfosvc;
        public CRMDetailsController(IClientInfo clientInfo , IProjectInfo projectInfo)
        {
            _clientInfosvc = clientInfo;
            _projectInfosvc = projectInfo;
        }

        public IActionResult CRMDetails()
        {
            CrmIndexViewModel model = new CrmIndexViewModel();
            model.clientList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Category--"},
                new SelectListItem {Text = "Active", Value = "1"},
                new SelectListItem {Text = "InActive", Value = "2"}
            };
            model.projectList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Project Client--"},
                new SelectListItem {Text = "Active", Value = "1"},
                new SelectListItem {Text = "InActive", Value = "2"}
            };

            model.employeeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Employee--"},
                new SelectListItem {Text = "demo5", Value = "1"},
                new SelectListItem {Text = "demo6", Value = "2"}
            };
            model.yearList = new List<SelectListItem>
            {
                new SelectListItem {Text = "--Select Year--"},
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
                new SelectListItem {Text = "--Select Month--"},
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
      
        public async Task<IActionResult> GetClientDetails(int? id)
        {
            var info = await _clientInfosvc.GetClientInfo("sw751");
            var vm = new CrmIndexViewModel()
            {
                client = info,
            };
            return View(vm);
        }


        public async Task<IActionResult> GetClientListDetails()
        {
            var info = await _clientInfosvc.Getclientlist();
            List<ClientDetails> vm = new List<ClientDetails>();
            vm = info;
            return View(vm);

            //for(int i = 0; i < info.Count; i++)
            //{
            //    vm.clientList.Add(new SelectListItem { Selected = true, Text = info.ElementAt(i + 1).ToString(), Value = (i + 2).ToString() });
            //}

        }

        [HttpPost]
        public async Task<IActionResult> SaveclientdetailsAsync(ClientDetails req)
        {
            var res = await _clientInfosvc.Saveclientdetails(req);
            if(res == true)
            {
                return RedirectToAction("CRMDetails");
            }
            else
            {
                return  RedirectToAction("ClientList");
            }
           

        }
        [HttpPost]
        public async Task<IActionResult> SaveProjectdetailsAsync(ProjectDetails req)
        {
            var res = await _projectInfosvc.Saveprojectdetails(req);
            if (res == true)
            {
                return RedirectToAction("CRMDetails");
            }
            else
            {
                return RedirectToAction("ProjectList");
            }


        }
     
        public IActionResult ProjectListViewDetails()
        {
            return View();
        }
        public IActionResult EmployeeTimeSheetView()
        {
            return View();
        }
    }
}