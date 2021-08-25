﻿using InvoiceMicroServices.WebMVC.AdminDashboard.Models;
using InvoiceMicroServices.WebMVC.AdminDashboard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
   public interface ICompanyInfo
    {
        Task<CompanyIndexViewModel> GetCompanyInfo(string id);
        Task<bool> SetCompanyInfo(CompanyIndexViewModel req);
    }
}
