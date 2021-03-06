using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public class CompanyInfoService : ICompanyInfo
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly string _remoteServiceBaseUri;

        public CompanyInfoService(ILogger<CompanyInfoService> logger,IOptionsSnapshot<AppSettings> appsettings,IHttpClient httpClient) 
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceBaseUri = $"{_appsettings.Value.CompanyinfoURl}/api/CompanyInfo/";
        }

        public async Task<CompanyInfo> GetCompanyInfo(string id)
        {
            var allinfourl = APIGateway.CompanyInfo.GetCompanyInfo(_remoteServiceBaseUri,id);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var response = JsonConvert.DeserializeObject<CompanyInfo>(datastring);
            return response;
        }
    }
}
