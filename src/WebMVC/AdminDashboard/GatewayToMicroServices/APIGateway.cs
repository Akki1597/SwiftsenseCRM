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
            public static string GetCompanyInfo(string baseuri, string companyId)
            {
                var res = $"{baseuri}GetCompanyDetails?companyId=" + companyId;
                return res;
            }
            public static string setCompanyInfo(string baseuri)
            {
                var res = $"{baseuri}SaveCompanyDetails";
                return res;
            }

        }
        public static class ClientInfo
        {
            public static string GetClientInfo(string baseuri, int? id)
            {
                var res = $"{baseuri}GetClientDetails?clientId=" +id;
                //var res = $"{baseuri}action?clientid=" + id;
                return res;
            }

            public static string setClientInfo(string baseuri)
            {
                var res = $"{baseuri}SaveClientDetails";
                return res;
            }
            public static string GetClientList(string baseuri, string status)
            {
                var res = $"{baseuri}GetClientList?status=" + status;
                return res;
            }
            public static string GetClientNameList(string baseuri, string status)
            {
                var res = $"{baseuri}GetClientNameList?status=" + status;
                return res;
            }
        }
        public static class ProjectInfo
        {
            public static string GetProjectInfo(string baseuri, string id)
            {
                var res = $"{baseuri}GetProjectDetails?projectId=" +id;
                return res;
            }

            public static string setProjectInfo(string baseuri)
            {
                var res = $"{baseuri}SaveProjectInfo";
                return res;
            }

            public static string GetProjectList(string baseuri, string status)
            {
                var res = $"{baseuri}GetProjectList?status=" + status;
                return res;
            }

            public static string GetProjectNameList(string baseuri, string status)
            {
                var res = $"{baseuri}GetProjectNameList?status=" + status;
                return res;
            }

            public static string GetProjectNamelistClientWise(string baseuri, int clientId)
            {
                var res = $"{baseuri}GetProjectNamelistClientWise?clientId=" + clientId;
                return res;
            }
        }
        public static class EmployeeInfo
        {
            public static string GetEmpNamelistProjectWise(string baseuri, string pId)

            {
                var res = $"{baseuri}GetEmpNamelistProjectWise?pId=" + pId;
                return res;
            }

            public static string GetEmpNamelistDetailsProjectWise(string baseuri, string pId)

            {
                var res = $"{baseuri}GetEmpNamelistDetailsProjectWise?pId=" + pId;
                return res;
            }
        }
    }
}
