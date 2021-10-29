using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public class AccountInfo : IAccount
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly string _remoteServiceregisterUri;
        private readonly string _remoteServiceGetuserListUri;
        private readonly string _remoteServiceUpdateuserUri;
        private readonly string _remoteServiceDeleteuserUri;

        public AccountInfo(ILogger<CompanyInfoService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceregisterUri = $"{_appsettings.Value.IdentityURL}/Account/Register/";
            _remoteServiceGetuserListUri = $"{_appsettings.Value.IdentityURL}/Account/GetUserList";
            _remoteServiceUpdateuserUri = $"{_appsettings.Value.IdentityURL}/Account/UpdateUserRole/";
            _remoteServiceDeleteuserUri = $"{_appsettings.Value.IdentityURL}/Account/DeleteUser";
        }

        
        public async Task<bool> Register(RegisterViewModel req)
        {
            var allinfourl = APIGateway.accountInfo.Register(_remoteServiceregisterUri);
             var response = await _apiclient.PostAsync(allinfourl,req);
             return response.IsSuccessStatusCode;
        }
        
        public async Task<List<UserDetails>> GetUserList(int userTypeId)
        {
            var allinfourl = APIGateway.accountInfo.GetUserList(_remoteServiceGetuserListUri, userTypeId);
            var response = await _apiclient.GetStringAsync(allinfourl);
            List<UserDetails> userList = new List<UserDetails>();
            userList = JsonConvert.DeserializeObject<List<UserDetails>>(response);
            return userList;
        }
        public async Task<bool> UpdateUserDetails(UserDetails userDetails)
        {
            var allinfourl = APIGateway.accountInfo.UpdatRole(_remoteServiceUpdateuserUri);
            var response = await _apiclient.PostAsync(allinfourl, userDetails);
            return response.IsSuccessStatusCode;
        }
        public async Task<string> Delete(string userId)
        {
            var allinfourl = APIGateway.accountInfo.DelteUser(_remoteServiceDeleteuserUri,userId);
            var response = await _apiclient.GetStringAsync(allinfourl);
            //var str = JsonConvert.DeserializeObject<string>(response);
            return response;
        }
    }
}
