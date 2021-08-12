using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using InvoiceMIcroServices.Data;
using InvoiceMIcroServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/ClientInfo/")]
    public class ClientInfoController : Controller
    {
        private readonly AdminDBContext _context;
        private readonly IOptionsSnapshot<UrlSettings> _settings;

        public ClientInfoController(IOptionsSnapshot<UrlSettings> settings, AdminDBContext context)
        {
            _settings = settings;
            _context = context;
            string url = settings.Value.ExternalServiceBaseUrl;
        }
        // GET: api/ClientInfo
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/ClientInfo/5
        [HttpGet("{id}")]
        [Route("GetClientDetails")]
        public ClientDetails GetClientInfo(int clientId)
        {
            try
            {
                if (clientId == 0)
                {
                    return new ClientDetails();
                }
                else
                {
                    var res = _context.clientDetails.Where(x => x.id == clientId).FirstOrDefault();
                    return res;
                }
            } 
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("GetClientList")]
        public List<ClientDetails> GetClientList()
        {
            try
            {
                var res =  _context.clientDetails.ToList();
                return res;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // POST: api/ClientInfo
        [HttpPost]
        [ProducesResponseType(typeof(ClientDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]ClientDetails clientInfo)
        {
            try
            {
                if (clientInfo.id != 0)
                {

                    var res = _context.clientDetails.Where(x => x.id == clientInfo.id).FirstOrDefault();

                    res.address = clientInfo.address;
                    res.name = clientInfo.name;
                    res.email = clientInfo.email;
                    res.unbilledHours = clientInfo.unbilledHours;
                    res.phoneNo = clientInfo.phoneNo;

                    _context.clientDetails.Update(res);
                    await _context.SaveChangesAsync();

                    return Ok(res);
                }
                else
                {

                    var newClient = new ClientDetails()
                    {
                        address = clientInfo.address,
                        name = clientInfo.name,
                        email = clientInfo.email,
                        unbilledHours = clientInfo.unbilledHours,
                        phoneNo = clientInfo.phoneNo,
                    };

                    _context.clientDetails.Add(newClient);
                    await _context.SaveChangesAsync();
                    return Ok(newClient);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/ClientInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
