using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public interface IEmployee
    {
        Task<IEnumerable<SelectListItem>> GetEmplist(string pId);
        Task<List<EmployeeDetails>> GetEmplistDetails(string pId);
        Task<List<EmployeeDetails>> GetEmplistDetails(string pId,string month,string year);
    }
}
