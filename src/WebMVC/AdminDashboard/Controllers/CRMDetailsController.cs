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
        private readonly IEmployee _employeesvc;
        public CRMDetailsController(IClientInfo clientInfo , IProjectInfo projectInfo,IEmployee employee)
        {
            _clientInfosvc = clientInfo;
            _projectInfosvc = projectInfo;
            _employeesvc = employee;
        }

        public async Task<IActionResult> CRMDetails()
        {
            var clientlist = await _clientInfosvc.Getclientlist("1");
            //var projectlist = await _projectInfosvc.Getprojectlist("1");

            CrmIndexViewModel model = new CrmIndexViewModel();
            model.clientStatusList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Client Status"},
                new SelectListItem {Text = "Active", Value = "1"},
                new SelectListItem {Text = "InActive", Value = "0"}
            };
            model.projectStatusList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Project Status "},
                new SelectListItem {Text = "Active", Value = "1"},
                new SelectListItem {Text = "InActive", Value = "0"}
            };

            List<ClientDetails> clist = await GetCLientlist();

            model.empClientList = new List<SelectListItem>();
            model.empClientList.Add(new SelectListItem { Text = "Select Client", Value ="0", Selected = true  });
            for (int i=0;i< clist.Count;i++)
            {
                model.empClientList.Add(new SelectListItem { Text = clist[i].name, Value = clist[i].id.ToString() });
            }
           
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

        public IActionResult AddNewClient()
        {
            ClientDetails vm  = new ClientDetails();
            return View(vm);
        }

        //public async Task<IActionResult> GetClientDetails(int? id)
        //{
        //    var info = await _clientInfosvc.GetClientInfo(id);
        //    var vm = new CrmIndexViewModel()
        //    {
        //        client = info,
        //    };
        //    return View(vm);
        //}

        public async Task<IActionResult> GetClientListDetails(string status)
        {
            var info = await _clientInfosvc.Getclientlist(status);
            List<ClientDetails> vm = new List<ClientDetails>();
            vm = info;
            return View(vm);

            //for(int i = 0; i < info.Count; i++)
            //{
            //    vm.clientList.Add(new SelectListItem { Selected = true, Text = info.ElementAt(i + 1).ToString(), Value = (i + 2).ToString() });
            //}

        }
       
        [HttpPost]
        public async Task<IActionResult> Saveclientdetails(ClientDetails req)
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

        /* Project Details */

        public IActionResult AddNewProject()
        {
            ProjectDetails vm = new ProjectDetails();
            return View(vm);
        }


        //public async Task<IActionResult> GetProjectDetails(int? id)
        //{
        //    var info = await _projectInfosvc.GetProjectInfo("");
        //    var vm = new CrmIndexViewModel()
        //    {
        //        project = info,
        //    };
        //    return View(vm);
        //}

        public async Task<IActionResult> GetProjectListDetails(string status)
        {
            var info = await _projectInfosvc.Getprojectlist(status);
            List<ProjectDetails> vm = new List<ProjectDetails>();
            vm = info;
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProjectdetails(ProjectDetails req)
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
        public IActionResult EmployeeTimeSheetView()
        {
            return View();
        }

        public async Task<List<ClientDetails>> GetCLientlist()
        {
            var res = await _clientInfosvc.Getclientlist("1");
            return res;
            
        }
        public async Task<ActionResult> GetEmplist(string pId)
        {
            IEnumerable<SelectListItem> response = await _employeesvc.GetEmplist(pId);
            var res = Json(response);
            return res;

        }

        public async Task<List<string>> GetProjectNames()
        {
            var res = await _projectInfosvc.GetprojectNamelist("1");
            return res;

        }
        public async Task<ActionResult> GetProjectNamesClientWise(int clientId)
        {
            IEnumerable<SelectListItem> response = await _projectInfosvc.GetprojectNamelistClientWise(clientId);
            var res = Json(response);
            return res;

        }
    }
}