using ITQJ.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProjectsController : BaseController
    {
        public ProjectsController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult GetProjects([FromQuery] int pageIndex, [FromQuery] int maxResults)
        {
            var projects = this._appDBContext.Projects
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();
            var projectsCount = this._appDBContext.Projects.Count();

            var pagesCount = (projectsCount == 0) ? 0
                           : (maxResults == 0) ? 0
                           : projectsCount / maxResults;

            if (projects is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            var projectsModel = this._mapper.Map<IEnumerable<ProjectResponseDTO>>(projects);

            return Ok(new
            {
                Message = "Ok",
                TotalCount = projectsCount,
                TotalPages = pagesCount,
                ResultCount = projectsModel.Count(),
                Result = projectsModel
            });
        }

        [HttpGet("{projectId}")]
        public ActionResult GetProject([FromRoute] int projectId)
        {
            var project = this._appDBContext.Projects
                .FirstOrDefault(x => x.Id == projectId);

            if (project is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            var projectModel = this._mapper.Map<ProjectResponseDTO>(project);

            return Ok(new
            {
                Message = "Ok",
                Result = projectModel
            });
        }
    }
}
