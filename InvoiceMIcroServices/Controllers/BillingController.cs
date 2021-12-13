using InvoiceMicroServices;
using InvoiceMicroServices.Models;
using InvoiceMIcroServices.Data;
using InvoiceMIcroServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Billing/")]
    public class BillingController : Controller
    {
        private readonly AdminDBContext _context;
        private readonly IOptionsSnapshot<UrlSettings> _settings;

        public BillingController(IOptionsSnapshot<UrlSettings> settings, AdminDBContext context)
        {
            _settings = settings;
            _context = context;
            string url = settings.Value.ExternalServiceBaseUrl;
        }

        [HttpPost]
        [Route("SaveInvoiceDetails")]
        [ProducesResponseType(typeof(InvoiceDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]billinginfo req)
        {
            try
            {
                var invoice = new InvoiceDetails()
                {
                    invoiceNo = req.invoiceNo,
                    date = req.date,
                    billingMonth = req.billingMonth,
                    billingYear = req.billingYear,
                    clientName = req.clientName,
                    projectName = req.projectName,
                    projectId = req.projectId,
                    totalAmount = req.totalAmount,
                    totalHours = req.totalHours,
                    clientId = req.clientId,
                    companyId = req.companyId
                };

                List<BillingRate> rate = new List<BillingRate>();
                
                foreach (var item in req.billingRate.Employees)
                {
                    BillingRate billingrate = new BillingRate();

                    billingrate.noofHours = item.NoofHours;
                    billingrate.employeeName = item.employeeName;
                    billingrate.rateperHr = item.RatePerHr;
                    billingrate.projectId = req.projectId;

                    rate.Add(billingrate);
                }


                _context.invoiceDetails.Add(invoice);
                _context.billingRate.AddRange(rate);
                await _context.SaveChangesAsync();
                return Ok(invoice);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("GetInvoiceCount")]
        public int GetInvoiceNo()
        {
            var count = _context.invoiceDetails.ToList().Count();
            return count;
        }


        [HttpGet]
        [Route("GetUnbilledHours")]
        public int GetUnbilledHours()
        {
            var res = _context.projectDetails.Where(x=> x.status == "Active").ToList();
            int count = 0;
            foreach(var item in res)
            {
                count += Convert.ToInt32(item.unbilledHours);
            }
            return count;
        }

        [HttpGet]
        [Route("GetInvoiceDetails")]
        public InvoiceDetails GetInvoiceDetails(string invoiceNumber)
        {
            var res = _context.invoiceDetails.Where(x=> x.invoiceNo == invoiceNumber).FirstOrDefault();
            return res;
        }

        [HttpGet]
        [Route("GetBillingRate")]
        public List<BillingRate> GetBillingRate(string projectId)
        {
            var res = _context.billingRate.Where(x => x.projectId == projectId).ToList();
            return res;
        }

        [HttpGet]
        [Route("GetInvoiceList")]
        public List<InvoiceDetails> GetInvoiceList(string id)
        {
            List<InvoiceDetails> invoiceDetails = new List<InvoiceDetails>();
            if (!string.IsNullOrEmpty(id))
            {

                var projectdetails = _context.projectDetails.Where(x => x.clientId.ToString() == id).FirstOrDefault();
                if (projectdetails == null)
                {
                    invoiceDetails = _context.invoiceDetails.Where(x => x.projectId == id).ToList();
                    return invoiceDetails;
                }
                else
                {
                    invoiceDetails = _context.invoiceDetails.Where(x => x.projectId == projectdetails.projectId).ToList();
                    return invoiceDetails;
                }

            }
            return invoiceDetails;

        }
    }
}
