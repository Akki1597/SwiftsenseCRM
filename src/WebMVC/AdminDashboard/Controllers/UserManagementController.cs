using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashboard.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserManagementController : Controller
    {
        private readonly IAccount _accountInfosvc;
        public UserManagementController(IAccount accountInfo)
        {
            _accountInfosvc = accountInfo;
        }

        public IActionResult Index()
        {
            UserManagement model = new UserManagement();
            model.usertypeList = new List<SelectListItem>
            {
                new SelectListItem {Text = "Select Type",Value=""},
                new SelectListItem {Text = "Employee", Value = "1"},
                new SelectListItem {Text = "Hr", Value = "2"}
            };
           
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ViewUserList(int userTypeId, UserManagement user)
        {
            if (userTypeId != 0)
            {
                ViewData["userTypeId"] = userTypeId;
                var res = await _accountInfosvc.GetUserList(userTypeId);
                return View(res);
            }
            else
            {
                ViewData["userTypeId"] = user.userTypeId;
                var res = await _accountInfosvc.GetUserList(user.userTypeId);
                return View(res);
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditUserDetails(int id,string userId)
        {
            UserDetails model = new UserDetails();

            var users = await _accountInfosvc.GetUserList(id);

            foreach(var user in users)
            {
                if(user.id == userId)
                {
                    model.id = user.id;
                    model.name = user.name;
                    model.email = user.email;
                    model.roles = user.roles;
                    model.roleId = user.roleId;
                }
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult UpdateUserDetails(UserDetails userDetails)
        {
            var res = _accountInfosvc.UpdateUserDetails(userDetails);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddUserDetails()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<bool> AddUserRole(UserManagement userrole)
        {
            var res = await _accountInfosvc.AddUserRole(userrole.name);
            return res;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserDetails(RegisterViewModel req)
        {
            var res = await _accountInfosvc.Register(req);
            return RedirectToAction("Index");
        }

        public IActionResult ViewUserToken()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<string> Delete(string userId)
        {
            var res = await _accountInfosvc.Delete(userId);
            return res;
        }

    }
}