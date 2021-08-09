using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels
{
    public class Common
    {
        public ClientDetails client { get; set; }
        public List<SelectListItem> clientList { get; set; }

        public ProjectDetails project { get; set; }
        public List<SelectListItem> projectList { get; set; }

        public EmployeeTimeSheet employee { get; set; }
        public List<SelectListItem> employeeList { get; set; }

        public YearList year { get; set; }
        public List<SelectListItem> yearList { get; set; }


        public MonthList month { get; set; }
        public List<SelectListItem> monthList { get; set; }

    }
}
