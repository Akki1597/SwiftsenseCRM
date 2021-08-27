using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private readonly ILogger<ProjectInfoService> _logger;
        private readonly string _remoteServiceBaseUri;

        public ProjectInfoService(ILogger<ProjectInfoService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
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

        public async Task<List<ProjectDetails>> Getprojectlist(string status)
        {
            var allinfourl = APIGateway.ProjectInfo.GetProjectList(_remoteServiceBaseUri, status);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            List<ProjectDetails> projectList = new List<ProjectDetails>();
            projectList = JsonConvert.DeserializeObject<List<ProjectDetails>>(datastring);
            return projectList;
        }

        public async Task<bool> Saveprojectdetails(ProjectDetails req)
        {
            var allinfourl = APIGateway.ProjectInfo.setProjectInfo(_remoteServiceBaseUri);
            var response = await _apiclient.PostAsync(allinfourl, req);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<List<string>> GetprojectNamelist(string status)
        {
            var allinfourl = APIGateway.ProjectInfo.GetProjectNameList(_remoteServiceBaseUri, status);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            List<string> projectNameList = new List<string>();
            projectNameList = JsonConvert.DeserializeObject<List<string>>(datastring);
            return projectNameList;
        }

        public async Task<IEnumerable<SelectListItem>> GetprojectNamelistClientWise(int clientId)
        {
            var allinfourl = APIGateway.ProjectInfo.GetProjectNamelistClientWise(_remoteServiceBaseUri, clientId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var projectlist = JsonConvert.DeserializeObject<IEnumerable<SelectListItem>>(datastring);
            return projectlist;
        }
    }
}
