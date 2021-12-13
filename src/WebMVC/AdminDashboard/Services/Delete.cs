using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public class Delete : IDelete
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly string _remoteServiceBaseUri;

        public Delete(ILogger<CompanyInfoService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceBaseUri = $"{_appsettings.Value.ServiceBaseURl}/api/Home/";
        }

     

        public async Task<string> deleteItem(string id)
        {
            var allinfourl = APIGateway.deleteInfo.deleteItem(_remoteServiceBaseUri,id);
            var response = await _apiclient.GetStringAsync(allinfourl);
            var str1 = JsonConvert.DeserializeObject<string>(response);
            return str1;
        }
    }
}
