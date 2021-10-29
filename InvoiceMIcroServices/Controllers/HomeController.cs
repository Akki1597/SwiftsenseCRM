using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMIcroServices.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private readonly AdminDBContext _context;
        private readonly IOptionsSnapshot<UrlSettings> _settings;

        public HomeController(IOptionsSnapshot<UrlSettings> settings, AdminDBContext context)
        {
            _settings = settings;
            _context = context;
            string url = settings.Value.ExternalServiceBaseUrl;
        }

        // DELETE: api/ApiWithActions/5
        [HttpGet]
        [Route("Delete")]
        public string Delete(string id)
        {
            if(!string.IsNullOrEmpty(id.ToString()))
            {
               
                var res = _context.clientDetails.Find(Convert.ToInt32(id));
                if(res != null){
                    _context.clientDetails.Remove(res);
                    _context.SaveChanges();
                    return "client";
                }
                else
                if (res == null)
                {
                    var res2 = _context.projectDetails.Where(x => x.projectId == id).FirstOrDefault();
                    if(res2 != null)
                    {
                        _context.projectDetails.Remove(res2);
                        _context.SaveChanges();
                        return "project";
                    }else
                    if (res2 == null)
                    {
                        var res3 = _context.invoiceDetails.Where(x => x.invoiceNo == id).FirstOrDefault();
                        if(res3 != null)
                        {
                            _context.invoiceDetails.Remove(res3);
                            _context.SaveChanges();
                            return "invoice";
                        }
                    }
                   
                }
            }
                return null;
        }
    }
}
