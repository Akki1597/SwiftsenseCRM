using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.GatewayToMicroServices
{
    public class APIGateway 
    {
        public static class CompanyInfo
        {
            public static string GetCompanyInfo(string baseuri,string id)
            {
                var res =  $"{baseuri}id";
                return res;
            }
            public static string setCompanyInfo(string baseuri)
            {
                var res = $"{baseuri}";
                return res;
            }

        }
        public static class ClientInfo
        {
            public static string GetClientInfo(string baseuri, string id)
            {
                var res = $"{baseuri}id";
                return res;
            }

            public static string setClientInfo(string baseuri)
            {
                var res = $"{baseuri}";
                return res;
            }
        }
       
    }
}
