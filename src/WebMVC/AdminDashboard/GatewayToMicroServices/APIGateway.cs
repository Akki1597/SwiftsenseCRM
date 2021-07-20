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
            public static string GetAllCompanyInfo(string baseuri)
            {
                return $"{baseuri}companyInfo";
            }
        }
       
    }
}
