﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Models
{
    public class DeleteUserViewModel
    {
        public int UserTypeId { get; set; }
        public string UserId { get; set; }
    }
}