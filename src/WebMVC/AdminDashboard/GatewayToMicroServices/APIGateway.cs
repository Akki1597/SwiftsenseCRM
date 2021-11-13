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
            public static string UpdateClientInfo(string baseuri)
            {
                var res = $"{baseuri}UpdateClientDetails";
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

            public static string GetProjectListClientWise(string baseuri, int clientId)
            {
                var res = $"{baseuri}GetProjectListClientWise?clientId=" + clientId;
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

            public static string GetEmpNamelistMonthWise(string baseuri, string pId)

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
        public static class Billinginfo
        {
            public static string setInvoicedetails(string baseuri)
            {
                var res = $"{baseuri}SaveInvoiceDetails";
                return res;
            }
            public static string getInvoiceCount(string baseuri)
            {
                var res = $"{baseuri}GetInvoiceCount";
                return res;
            }

            public static string GetUnbilledHours(string baseuri)
            {
                var res = $"{baseuri}GetUnbilledHours";
                return res;
            }

            public static string getInvoiceList(string baseuri,string id)
            {
                var res = $"{baseuri}GetInvoiceList?id="+id;
                return res;
            }

            public static string getBillingrate(string baseuri, string projectId)
            {
                var res = $"{baseuri}GetBillingRate?projectId=" + projectId;
                return res;
            }

            public static string getInvoiceDetails(string baseuri, string invoiceNumber)
            {
                var res = $"{baseuri}GetInvoiceDetails?invoiceNumber=" + invoiceNumber;
                return res;
            }
        }
        public static class deleteInfo
        {
            public static string deleteItem(string baseuri, string id)
            {
                var res = $"{baseuri}Delete?id=" + id;
                return res;
            }
        }

        public static class accountInfo
        {
            public static string Register(string baseuri)
            {
                var res = $"{baseuri}";
                return res;
            }

            public static string GetUserList(string baseuri,int typeid)
            {
                var res = $"{baseuri}?userTypeId="+ typeid;
                return res;
            }

            public static string AddNewRole(string baseuri, string name)
            {
                var res = $"{baseuri}?name=" + name;
                return res;
            }

            public static string UpdatRole(string baseuri)
            {
                var res = $"{baseuri}";
                return res;
            }

            public static string DelteUser(string baseuri, string userId)
            {
                var res = $"{baseuri}?UserId=" +userId; 
                return res;
            }
        }
    }
}
