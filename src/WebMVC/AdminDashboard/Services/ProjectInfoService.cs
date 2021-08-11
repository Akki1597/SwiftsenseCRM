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
    public class ProjectInfoService : IProjectInfo
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly string _remoteServiceBaseUri;

        public ProjectInfoService(ILogger<CompanyInfoService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceBaseUri = $"{_appsettings.Value.ServiceBaseURl}/api/ProjectInfo/";
        }

        public async Task<ProjectDetails> GetProjectInfo(string projectId)
        {
            var allinfourl = APIGateway.ProjectInfo.GetProjectInfo(_remoteServiceBaseUri, projectId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var response = JsonConvert.DeserializeObject<ProjectDetails>(datastring);
            return response;
        }

        public Task<bool> Getprojectlist(List<ProjectDetails> req)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Saveprojectdetails(ProjectDetails req)
        {
            var allinfourl = APIGateway.ProjectInfo.setProjectInfo(_remoteServiceBaseUri);
            var response = await _apiclient.PostAsync(allinfourl, req);
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
