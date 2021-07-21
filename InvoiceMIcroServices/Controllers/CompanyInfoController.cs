using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceMIcroServices.Data;
using InvoiceMIcroServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/CompanyInfo")]
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

        [HttpGet]
        [Route("action")]
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
        [Route("action")]
        public async Task<string> SetCompanyInfo(CompanyInfo companyInfo)
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

                    return "Company information updated successfully";
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
                    return "New company information added successfully";
                }
            }
            catch(Exception ex)
            {
                throw  ex;
            }
           
        }
    }
}