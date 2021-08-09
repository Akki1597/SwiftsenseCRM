using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InvoiceMIcroServices.Data;
using InvoiceMIcroServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/CompanyInfo")]
    //[Authorize]
    public class CompanyInfoController : Controller
    {
        private readonly AdminDBContext _context;
        private readonly IOptionsSnapshot<UrlSettings> _settings;

        public CompanyInfoController(IOptionsSnapshot<UrlSettings> settings, AdminDBContext context)
        {
            _settings = settings;
            _context = context;
            string url = settings.Value.ExternalServiceBaseUrl;
        }

        [HttpGet("{id}")]
        public CompanyInfo GetCompanyInfo(string companyId)
        {
            try
            {
                if(companyId == null)
                {
                    return  new CompanyInfo();
                }
                else
                {
                    var res =  _context.CompanyInfo.Where(x=> x.companyId == companyId).FirstOrDefault();
                    return  res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]CompanyInfo companyInfo)
        {
            try
            {
                Random rand = new Random();
                int num = rand.Next(1, 1000);
                var cId = companyInfo.companyName.Substring(0, 2) + num;
                if (companyInfo.id != 0)
                {

                    var res =  _context.CompanyInfo.Where(x=> x.companyId == companyInfo.companyId).FirstOrDefault();

                    res.address = companyInfo.address;
                    res.companyName = companyInfo.companyName;
                    res.email = companyInfo.email;
                    res.gstNo = companyInfo.gstNo;
                    res.phoneNo = companyInfo.phoneNo;

                    _context.CompanyInfo.Update(res);
                    await _context.SaveChangesAsync();

                    return Ok(res);
                }
                else
                {

                    var newCompany = new CompanyInfo()
                    {
                        companyId = cId,
                        address = companyInfo.address,
                        companyName = companyInfo.companyName,
                        email = companyInfo.email,
                        gstNo = companyInfo.gstNo,
                        phoneNo = companyInfo.phoneNo
                    };

                    _context.CompanyInfo.Add(newCompany);
                   await _context.SaveChangesAsync();
                    return  Ok(newCompany);
                }
            }
            catch(Exception ex)
            {
                throw  ex;
            }
           
        }
    }
}