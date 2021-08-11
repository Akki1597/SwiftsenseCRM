using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
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
        Task<bool> Getprojectlist(List<ProjectDetails> req);
    }
}
