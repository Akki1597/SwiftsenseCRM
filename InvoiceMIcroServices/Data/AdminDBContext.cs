using InvoiceMIcroServices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Data
{
    public class AdminDBContext:DbContext
    {
        public AdminDBContext(DbContextOptions options) : base(options)
        {
         
        }
        public DbSet<CompanyInfo> CompanyInfo { get; set; }
        public DbSet<ClientInfo> clientInfo { get; set; }
        public DbSet<ClientInfo> projectInfo { get; set; }

    }
}
