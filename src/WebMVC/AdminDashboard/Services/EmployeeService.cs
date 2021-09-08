using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<EmployeeService> _logger;
        private readonly string _remoteServiceBaseUri;

        public EmployeeService(ILogger<EmployeeService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceBaseUri = $"{_appsettings.Value.ServiceBaseURl}/api/Employee/";
        }

        public async Task<IEnumerable<SelectListItem>> GetEmplist(string pId)
        {
            var allinfourl = APIGateway.EmployeeInfo.GetEmpNamelistProjectWise(_remoteServiceBaseUri, pId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var emplist = JsonConvert.DeserializeObject<IEnumerable<SelectListItem>>(datastring);
            return emplist;
        }

        public async Task<IEnumerable<SelectListItem>> GetEmplist(string pId,string month,string year)
        {
            var allinfourl = APIGateway.EmployeeInfo.GetEmpNamelistMonthWise(_remoteServiceBaseUri, pId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var emplist = JsonConvert.DeserializeObject<IEnumerable<SelectListItem>>(datastring);
            return emplist;
        }

        public async Task<List<EmployeeDetails>> GetEmplistDetails(string pId)
        {
            var allinfourl = APIGateway.EmployeeInfo.GetEmpNamelistDetailsProjectWise(_remoteServiceBaseUri, pId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var emplist = JsonConvert.DeserializeObject<List<EmployeeDetails>>(datastring);
            return emplist;
        }
    }
}
