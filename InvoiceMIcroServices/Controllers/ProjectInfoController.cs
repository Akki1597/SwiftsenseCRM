using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using InvoiceMIcroServices.Data;
using InvoiceMIcroServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InvoiceMIcroServices.Controllers
{
    [Produces("application/json")]
    [Route("api/ProjectInfo/")]
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
    
        [HttpGet]
        [Route("GetProjectDetails")]
        public ProjectDetails GetProjectInfo(string projectId)
        {
            try
            {
                if (string.IsNullOrEmpty(projectId))
                {
                    return new ProjectDetails();
                }
                else
                {
                    var res = _context.projectDetails.Where(x => x.projectId == projectId).FirstOrDefault();
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("GetProjectList")]
        public List<ProjectDetails> GetProjectList(string status)
        {
            try
            {
                List<ProjectDetails> res = new List<ProjectDetails>();
                if(status == "1")
                {
                     res = _context.projectDetails.Where(x => x.status == "Active").ToList();
                }
                if (status == "0")
                {
                     res = _context.projectDetails.Where(x => x.status == "InActive").ToList();
                }
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpGet]
        [Route("GetProjectNameList")]
        public List<string> GetProjectNameList(string status)
        {
            try
            {
                List<string> res = new List<string>();
                if (status == "1")
                {
                    res = _context.projectDetails.Where(x => x.status == "Active").Select(x=> x.name).ToList();
                }
                
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpGet]
        [Route("GetProjectNamelistClientWise")]
        public IEnumerable<SelectListItem> GetProjectNamelistClientWise(int clientId)
        {
            try
            {
                List<SelectListItem> prolist = _context.projectDetails.AsNoTracking()
             .OrderBy(x => x.name)
              .Where(x => x.clientId == clientId)
                 .Select(x =>
                 new SelectListItem
                 {
                     Value = x.id.ToString(),
                     Text = x.name,
                     Selected = false
                 }).ToList();

                var prolistinitial = new SelectListItem()
                {
                    Value = "0",
                    Text = "Select Project Name",
                    Selected = true
                };
                prolist.Insert(0, prolistinitial);

                return new SelectList(prolist, "Value", "Text", "Selected");

            }
            catch (Exception ex)
            {
                return null;
            }

        }


        [HttpGet]
        [Route("GetProjectListClientWise")]
        public List<ProjectDetails> GetProjectListClientWise(int clientId)
        {
            try
            {
                List<ProjectDetails> prolist = _context.projectDetails.Where(x => x.clientId == clientId).ToList();
                if(prolist != null)
                    return prolist;
               
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // POST: api/ProjectInfo
        [HttpPost]
        [Route("SaveProjectInfo")]
        [ProducesResponseType(typeof(ProjectDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody]ProjectDetails projectInfo)
        {
            try
            {
                if (!string.IsNullOrEmpty(projectInfo.projectId))
                {

                    var res = _context.projectDetails.Where(x => x.id == projectInfo.id).FirstOrDefault();
                    if (res != null)
                    {
                        res.name = projectInfo.name;
                        res.pCode = projectInfo.pCode;
                        res.status = projectInfo.status;
                        res.clientId = projectInfo.clientId;
                        res.projectId = projectInfo.projectId;
                        res.unbilledHours = projectInfo.unbilledHours;

                        _context.projectDetails.Update(res);
                        await _context.SaveChangesAsync();

                        return Ok(res);
                    }
                    else
                    {
                        var newProject = new ProjectDetails()
                        {
                            name = projectInfo.name,
                            pCode = projectInfo.pCode,
                            status = "Active",
                            clientId = projectInfo.clientId,
                            projectId = projectInfo.projectId,
                            unbilledHours = projectInfo.unbilledHours,
                        };

                        _context.projectDetails.Add(newProject);
                        await _context.SaveChangesAsync();
                        return Ok(newProject);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     
    }
}
