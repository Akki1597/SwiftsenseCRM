using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public interface IAccount
    {
        Task<bool> Register(RegisterViewModel req);
        Task<List<UserDetails>> GetUserList(int userTypeId);
        Task<bool> UpdateUserDetails(UserDetails userDetails);
        Task<string> Delete(string userId);
    }
}
