using ITQJ.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITQJ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : BaseController
    {
        public ProjectsController(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        [HttpGet]
        public ActionResult GetProjects([FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 20)
        {
            var projects = this._appDBContext.Projects
                .Where(x => x.PostulantsLimit > x.Postulants.Count() && x.IsOpen == true)
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();
            var projectsCount = this._appDBContext.Projects
                .Where(x => x.PostulantsLimit > x.Postulants.Count() && x.IsOpen == true)
                .Count();


            var pagesCount = (projectsCount == 0) ? 0
                           : (maxResults == 0) ? 0
                           : projectsCount / maxResults;

            var projectsModel = this._mapper.Map<IEnumerable<ProjectResponseDTO>>(projects);

            return Ok(new
            {
                Message = "Ok",
                Result = new
                {
                    TotalCount = projectsCount,
                    TotalPages = pagesCount,
                    ResultCount = projectsModel.Count(),
                    Projects = projectsModel
                }
            });
        }

        [HttpGet("{projectId}")]
        public ActionResult GetProject([FromRoute] Guid projectId)
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

        [Authorize]
        [HttpGet("/myprojects/{projectId}")]
        public ActionResult GetUserProject([FromRoute] Guid projectId)
        {
            var ownerId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            var project = this._appDBContext.Projects
                .Include(i => i.Postulants)
                .Include(i => i.Messages)
                .FirstOrDefault(x => x.Id == projectId && x.UserId == Guid.Parse(ownerId));

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
