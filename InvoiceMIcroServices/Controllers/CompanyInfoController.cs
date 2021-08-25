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
    [Route("api/CompanyInfo/")]
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

        [HttpGet]
        [Route("GetCompanyDetails")]
        public CompanyDetails GetCompanyInfo(string companyId)
        {
            try
            {
                if (companyId == null)
                {
                    return new CompanyDetails();
                }
                else
                {
                    var res = (from c in _context.CompanyInfo
                               join b in _context.bankDetails on c.companyId equals b.companyId
                               where c.companyId.ToString() == companyId
                               select new CompanyDetails()
                               {
                                   address = c.address,
                                   companyName = c.companyName,
                                   companyId = c.companyId,
                                   id = c.id,
                                   email = c.email,
                                   gstNo = c.gstNo,
                                   phoneNo = c.phoneNo,
                                   bankName = b.bankName,
                                   accountNumber = b.accountNumber,
                                   swiftCode = b.swiftCode,
                                   name = b.name,
                               }).FirstOrDefault();

                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanyDetails), (int)HttpStatusCode.OK)]
        [Route("SaveCompanyDetails")]
        public async Task<IActionResult> Post([FromForm]CompanyDetails req)
        {
            try
            {
                Random rand = new Random();
                int num = rand.Next(1, 1000);
                var cId = req.companyName.Substring(0, 2) + num;
                if (!string.IsNullOrEmpty(req.companyId))
                {

                    var res = _context.CompanyInfo.Where(x => x.companyId == req.companyId).FirstOrDefault();
                    var res1 = _context.bankDetails.Where(x => x.companyId == req.companyId).FirstOrDefault();

                    res.address = req.address;
                    res.companyName = req.companyName;
                    res.email = req.email;
                    res.gstNo = req.gstNo;
                    res.phoneNo = req.phoneNo;

                    res1.bankName = req.bankName;
                    res1.accountNumber = req.accountNumber;
                    res1.swiftCode = req.swiftCode;
                    res1.name = req.name;


                    _context.CompanyInfo.Update(res);
                    _context.bankDetails.Update(res1);
                    await _context.SaveChangesAsync();

                    return Ok(req);
                }
                else
                {

                    var newCompany = new CompanyInfo()
                    {
                        companyId = cId,
                        address = req.address,
                        companyName = req.companyName,
                        email = req.email,
                        gstNo = req.gstNo,
                        phoneNo = req.phoneNo
                    };

                    var bankDetails = new BankDetails()
                    {
                        companyId = cId,
                        name = req.name,
                        swiftCode = req.swiftCode,
                        accountNumber = req.accountNumber,
                        bankName = req.bankName
                    };

                    _context.CompanyInfo.Add(newCompany);
                    _context.bankDetails.Add(bankDetails);
                    await _context.SaveChangesAsync();
                    return Ok(req);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}