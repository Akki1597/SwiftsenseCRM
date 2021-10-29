using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.Services;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IAccount _accountinfosvc;
        //public AccountController(IAccount accountinfo)
        //{
        //    _accountinfosvc = accountinfo;
        //}

        [Authorize]
        public async Task<IActionResult> SignIn()
        {
            //var user = User as ClaimsPrincipal;

            //var token = await HttpContext.GetTokenAsync("access_token");
            //var idToken = await HttpContext.GetTokenAsync("id_token");
            ////var role = user.Claims.;
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return RedirectToAction("Index", "AdminHomePage");

            //foreach (var claim in user.Claims)
            //{
            //    Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value : {claim.Value}");
            //}

            //if (token != null)
            //{
            //    ViewData["access_token"] = token;

            //}
            //if (idToken != null)
            //{

            //    ViewData["id_token"] = idToken;
            //}
            //// "Catalog" because UrlHelper doesn't support nameof() for controllers
            //// https://github.com/aspnet/Mvc/issues/5853
           
        }

        //[HttpPost]
        //public async Task<bool> GetLogin(LoginViewModel model)
        //{
        //    var res = await ;
        //    return true;
        //}

        [HttpPost]
        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            ////// "Catalog" because UrlHelper doesn't support nameof() for controllers
            ////// https://github.com/aspnet/Mvc/issues/5853
            var homeUrl = Url.Action(nameof(HomeController.Index), "Home");
            
            return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme,
                new AuthenticationProperties { RedirectUri = homeUrl });
            
            //return SignOut(CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        [Route("/Account/AccessDenied")]
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}