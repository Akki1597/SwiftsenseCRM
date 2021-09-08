using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public interface IClientInfo
    {
        Task<ClientDetails> GetClientInfo(int? clientId);
        Task<bool> Saveclientdetails(ClientDetails req);
        Task<List<ClientDetails>> Getclientlist(string status);
        //Task<List<ClientDetails>> GetclientNamelist(string status);
    }
}
