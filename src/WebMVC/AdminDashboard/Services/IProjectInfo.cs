using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public interface IProjectInfo
    {
        Task<ProjectDetails> GetProjectInfo(string projectId);
        Task<bool> Saveprojectdetails(ProjectDetails req);
        Task<List<ProjectDetails>> Getprojectlist(string status);
        Task<List<string>> GetprojectNamelist(string status);
        Task<IEnumerable<SelectListItem>> GetprojectNamelistClientWise(int clientId);
        Task<List<ProjectDetails>> GetprojectListDetailsClientWise(int clientId);
    }
}
