using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace InvoiceMicroServices.WebMVC.AdminDashboard.Services
{
    public interface IIdentityService<T>
    {
        T Get(IPrincipal principal);
    }
}
