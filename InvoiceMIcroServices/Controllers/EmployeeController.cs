using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMIcroServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly AdminDBContext _context;
        private readonly IOptionsSnapshot<UrlSettings> _settings;

        public EmployeeController(IOptionsSnapshot<UrlSettings> settings, AdminDBContext context)
        {
            _settings = settings;
            _context = context;
            string url = settings.Value.ExternalServiceBaseUrl;
        }

        [HttpGet]
        [Route("GetEmpNamelistProjectWise")]
        public IEnumerable<SelectListItem> GetEmpNamelistProjectWise(int pId)
        {
            try
            {
                List<SelectListItem> emplist = _context.employeeDetails.AsNoTracking()
             .OrderBy(x => x.firstName)
              .Where(x => x.projectId == pId)
                 .Select(x =>
                 new SelectListItem
                 {
                     Value = x.id.ToString(),
                     Text = x.firstName + x.lastName,
                     Selected = false
                 }).ToList();

                var prolistinitial = new SelectListItem()
                {
                    Value = "0",
                    Text = "--- Select Employee Name ---",
                    Selected = true
                };
                emplist.Insert(0, prolistinitial);

                return new SelectList(emplist, "Value", "Text", "Selected");

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
