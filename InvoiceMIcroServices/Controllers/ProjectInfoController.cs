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
    [Route("api/ProjectInfo")]
    public class ProjectInfoController : Controller
    {
        private readonly AdminDBContext _context;
        private readonly IOptionsSnapshot<UrlSettings> _settings;

        public ProjectInfoController(IOptionsSnapshot<UrlSettings> settings, AdminDBContext context)
        {
            _settings = settings;
            _context = context;
            string url = settings.Value.ExternalServiceBaseUrl;
        }
        // GET: api/ProjectInfo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ProjectInfo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/ProjectInfo
        [HttpPost]
        [ProducesResponseType(typeof(ProjectInfo), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]ProjectInfo projectInfo)
        {
            try
            {
                if (projectInfo.id != 0)
                {

                    var res = _context.projectInfo.Where(x => x.id == projectInfo.id).FirstOrDefault();

                    res.projectname = projectInfo.projectname;
                    res.projectcode = projectInfo.projectcode;
                    res.proId = projectInfo.proId;
                    res.projectState = projectInfo.projectState;
                    res.projectType = projectInfo.projectType;
                    res.unbilledHours = projectInfo.unbilledHours;

                    _context.clientInfo.Update(res);
                    await _context.SaveChangesAsync();

                    return Ok(res);
                }
                else
                {

                    var newProject = new ProjectInfo()
                    {
                        projectname = projectInfo.projectname,
                        projectcode = projectInfo.projectcode,
                        proId = projectInfo.proId,
                        projectState = projectInfo.projectState,
                        projectType = projectInfo.projectType,
                        unbilledHours = projectInfo.unbilledHours,
                };

                    _context.projectInfo.Add(newProject);
                    await _context.SaveChangesAsync();
                    return Ok(newProject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PUT: api/ProjectInfo/5
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
