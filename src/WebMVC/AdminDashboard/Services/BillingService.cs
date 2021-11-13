using InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices;
using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public class BillingService : IBillingInfo
    {
        private readonly IOptionsSnapshot<AppSettings> _appsettings;
        private readonly IHttpClient _apiclient;
        private readonly ILogger<CompanyInfoService> _logger;
        private readonly string _remoteServiceBaseUri;

        public BillingService(ILogger<CompanyInfoService> logger, IOptionsSnapshot<AppSettings> appsettings, IHttpClient httpClient)
        {
            _appsettings = appsettings;
            _logger = logger;
            _apiclient = httpClient;
            _remoteServiceBaseUri = $"{_appsettings.Value.ServiceBaseURl}/api/Billing/";
        }

        public async Task<InvoiceDetails> GetInvoiceDetails(string invoiceNumber)
        {
            var allinfourl = APIGateway.Billinginfo.getInvoiceDetails(_remoteServiceBaseUri, invoiceNumber);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            InvoiceDetails invoiceDetails = new InvoiceDetails();
            invoiceDetails = JsonConvert.DeserializeObject<InvoiceDetails>(datastring);
            return invoiceDetails;
        }

        public async Task<bool> SaveInvoiceDetails(InvoiceDetails req)
        {
            var allinfourl = APIGateway.Billinginfo.setInvoicedetails(_remoteServiceBaseUri);
            var response = await _apiclient.PostAsync(allinfourl, req);
            response.EnsureSuccessStatusCode();
            return true;
        }
        public async Task<int> GetInvoiceCount()
        {
            var allinfourl = APIGateway.Billinginfo.getInvoiceCount(_remoteServiceBaseUri);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            return Convert.ToInt32(datastring);
        }

        public async Task<int> GetUnbilledHours()
        {
            var allinfourl = APIGateway.Billinginfo.GetUnbilledHours(_remoteServiceBaseUri);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            return Convert.ToInt32(datastring);
        }

        public async Task<string> GetInvoiceList(string id)
        {
            var allinfourl = APIGateway.Billinginfo.getInvoiceList(_remoteServiceBaseUri,id);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            //List<InvoiceDetails> invoicelist = new List<InvoiceDetails>();
            //invoicelist = JsonConvert.DeserializeObject<List<InvoiceDetails>>(datastring);
            return datastring;
        }

        public async Task<List<ResBillingRate>> GetBillingRate(string projectId)
        {
            var allinfourl = APIGateway.Billinginfo.getBillingrate(_remoteServiceBaseUri, projectId);
            var datastring = await _apiclient.GetStringAsync(allinfourl);
            List<ResBillingRate> billingratelist = new List<ResBillingRate>();
            billingratelist = JsonConvert.DeserializeObject<List<ResBillingRate>>(datastring);
            return billingratelist;
        }
    }
}
