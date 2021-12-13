using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public class ClientInfoService : IClientInfo
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly string _remoteServiceBaseUri;

        public ClientInfoService(ILogger<CompanyInfoService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceBaseUri = $"{_appsettings.Value.ServiceBaseURl}/api/ClientInfo/";
        }

        public async Task<ClientDetails> GetClientInfo(int? clientId)
        {
            var allinfourl = APIGateway.ClientInfo.GetClientInfo(_remoteServiceBaseUri, clientId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            var response = JsonConvert.DeserializeObject<ClientDetails>(datastring);
            return response;
        }

        public async Task<List<ClientDetails>> Getclientlist(string status)
        {
            var allinfourl = APIGateway.ClientInfo.GetClientList(_remoteServiceBaseUri, status);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            List<ClientDetails> clientList = new List<ClientDetails>();
            clientList = JsonConvert.DeserializeObject<List<ClientDetails>>(datastring);
            return clientList;
        }
        //public async Task<List<ClientDetails>> GetclientNamelist(string status)
        //{
        //    var allinfourl = APIGateway.ClientInfo.GetClientNameList(_remoteServiceBaseUri, status);
        //    var datastring = await _apiclient.GetStringAsync(allinfourl);
        //    List<ClientDetails> clientNameList = new List<ClientDetails>();
        //    clientNameList = JsonConvert.DeserializeObject<List<ClientDetails>>(datastring);
        //    return clientNameList;
        //}

        public async Task<bool> Saveclientdetails(ClientDetails req)
        {
            var allinfourl = APIGateway.ClientInfo.setClientInfo(_remoteServiceBaseUri);
            var response = await _apiclient.PostAsync(allinfourl,req);
            response.EnsureSuccessStatusCode();
            return true;
        }
        //public async Task<bool> Updateclientdetails(ClientDetails req)
        //{
        //    var allinfourl = APIGateway.ClientInfo.UpdateClientInfo(_remoteServiceBaseUri);
        //    var response = await _apiclient.PostAsync(allinfourl, req);
        //    response.EnsureSuccessStatusCode();
        //    return true;
        //}
    }
}
