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
        public ActionResult GetProjects([FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 5)
        {
            if (pageIndex < 1)
                return BadRequest(new { Error = $"Error: value for pageIndex={pageIndex} is lower than the minimund expected." });

            if (maxResults < 5)
                return BadRequest(new { Error = $"Error: value for maxResults={maxResults} is lower than the minimund expected." });

            var projects = this._appDBContext.Projects
                .Where(x => x.PostulantsLimit > x.Postulants.Count() && x.IsOpen == true)
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();

            var projectsCount = this._appDBContext.Projects
                .Where(x => x.PostulantsLimit > x.Postulants.Count() && x.IsOpen == true)
                .Count();

            var pagesCount = Math.Ceiling((float)projectsCount / (float)maxResults);

            var projectsModel = this._mapper.Map<IEnumerable<ProjectResponseDTO>>(projects);

            return Ok(new
            {
                Message = "Ok",
                Result = new
                {
                    pageIndex = pageIndex,
                    TotalCount = projectsCount,
                    TotalPages = pagesCount,
                    ResultCount = projectsModel.Count(),
                    Projects = projectsModel
                }
            });
        }

        [HttpGet("current/{userId}")]
        public ActionResult GetContratistProjects([FromRoute] Guid userId, [FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 5)
        {
            if (userId == null)
                return BadRequest(new { Message = $"Error: el parametro {nameof(userId)} no puede ser nulo." });

            if (pageIndex < 1)
                return BadRequest(new { Error = $"Error: value for pageIndex={pageIndex} is lower than the minimund expected." });

            if (maxResults < 5)
                return BadRequest(new { Error = $"Error: value for maxResults={maxResults} is lower than the minimund expected." });

            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.Id == userId);

            if (user is null)
                return NotFound(new { Message = "Error: El recurso no ha sido encontrado." });

            var projects = this._appDBContext.Projects
                .Where(x => x.UserId == user.Id && x.DeletedFlag == false)
                .Skip((pageIndex - 1) * maxResults)
                .Take(maxResults)
                .ToList();

            var projectsCount = this._appDBContext.Projects
                .Where(x => x.UserId == user.Id && x.DeletedFlag == false)
                .Count();

            var pagesCount = Math.Ceiling((float)projectsCount / (float)maxResults);

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
        public ActionResult GetProjectById([FromRoute] Guid projectId)
        {
            if (projectId == null)
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

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
        public ActionResult GetUserProjectInfo([FromRoute] Guid projectId)
        {
            if (projectId == null)
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            var subject = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.Subject == subject);

            var project = this._appDBContext.Projects
                .Include(i => i.Postulants)
                .Include(i => i.Messages)
                .FirstOrDefault(x => x.Id == projectId && x.UserId == user.Id);

            if (project is null)
                return NotFound(new { Message = "Error: El recurso no ha sido encontrado." });

            var projectModel = this._mapper.Map<ProjectResponseDTO>(project);

            return Ok(new
            {
                Message = "Ok",
                Result = projectModel
            });
        }
    }
}
