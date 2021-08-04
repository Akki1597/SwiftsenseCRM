using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Exceptions
{
    public class AdminDashboardException:Exception
    {
        public AdminDashboardException()
        { }

        public AdminDashboardException(string message)
            : base(message)
        { }

        public AdminDashboardException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
