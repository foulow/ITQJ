using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
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
                    TotalCount = projectsCount,
                    ResultCount = projectsModel.Count(),
                    TotalPages = pagesCount,
                    PageIndex = pageIndex,
                    Projects = projectsModel
                }
            });
        }


        [HttpGet("current/{userId}")]
        public ActionResult GetContratistProjects([FromRoute] Guid userId, [FromQuery] int pageIndex = 1, [FromQuery] int maxResults = 5)
        {
            if (userId == null || userId == new Guid())
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
                    ResultCount = projectsModel.Count(),
                    TotalPages = pagesCount,
                    PageIndex = pageIndex,
                    Projects = projectsModel
                }
            });
        }

        [HttpGet("{projectId}")]
        public ActionResult GetProjectById([FromRoute] Guid projectId)
        {
            if (projectId == null || projectId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            var project = this._appDBContext.Projects
                .Include(i => i.User)
                .Include(i => i.Postulants)
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
        [HttpGet("myprojects/{projectId}")]
        public ActionResult GetUserProjectInfo([FromRoute] Guid projectId)
        {
            if (projectId == null || projectId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            var subject = HttpContext.User.Claims
                .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            var user = this._appDBContext.Users
                .FirstOrDefault(x => x.Subject == subject);

            var project = this._appDBContext.Projects
                .Include(i => i.Postulants)
                .Include(i => i.Messages)
                .FirstOrDefault(x => x.Id == projectId && x.UserId == user.Id);

            var projectModel = this._mapper.Map<ProjectResponseDTO>(project);

            return Ok(new
            {
                Message = "Ok",
                Result = projectModel
            });
        }


        [Authorize]
        [HttpPost]
        public ActionResult RegisterProject([FromBody] ProjectCreateDTO projectData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro del proyecto son invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var newProject = this._mapper.Map<Project>(projectData);

            if (newProject == null)
                return BadRequest(new { Error = "No se enviaron los datos esperados." });

            var tempProject = this._appDBContext.Projects.Add(newProject);
            this._appDBContext.SaveChanges();

            var projectModel = this._mapper.Map<ProjectResponseDTO>(tempProject.Entity);

            return Ok(new
            {
                Message = "Ok",
                Result = projectModel
            });
        }


        [Authorize]
        [HttpPut("myprojects/{projectId}")]
        public ActionResult UpdateProject([FromRoute] Guid projectId, [FromBody] ProjectUpdateDTO projectData)
        {
            if (projectId == null || projectId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "La informacion de registro de skills de usuario invalidos.",
                    ErrorsCount = ModelState.ErrorCount,
                    Errors = ModelState.Select(x => x.Value.Errors)
                });
            }

            var projectToUpdate = this._appDBContext.Projects.FirstOrDefault(item => item.Id == projectId);

            if (projectToUpdate != null)
            {
                this._mapper.Map<ProjectUpdateDTO, Project>(projectData, projectToUpdate);

                var tempProjectToUpdate = this._appDBContext.Projects.Update(projectToUpdate);
                this._appDBContext.SaveChanges();

                var projectModel = this._mapper.Map<ProjectResponseDTO>(tempProjectToUpdate.Entity);

                return Ok(new
                {
                    Message = "Ok",
                    Result = projectModel
                });
            }
            else
            {
                return NotFound(new { Message = "El recurso a actualizar no ha sido encontrado." });
            }
        }


        [HttpDelete("{projectId}")]
        public ActionResult CloseProyect([FromRoute] Guid projectId, [FromQuery] bool deleteAlso = false)
        {
            if (projectId == null || projectId == new Guid())
                return BadRequest(new { Message = $"Error: el parametro {nameof(projectId)} no puede ser nulo." });

            var projectToUpdate = this._appDBContext.Projects
                .FirstOrDefault(x => x.Id == projectId && x.IsOpen == true);

            if (projectToUpdate is null)
                return NotFound(new { Error = "El recurso no ha sido encontrado." });

            projectToUpdate.IsOpen = true;
            projectToUpdate.DeletedFlag = deleteAlso;

            this._appDBContext.Projects.Update(projectToUpdate);
            this._appDBContext.SaveChanges();

            return Ok(new
            {
                Message = "Ok"
            });
        }
    }
}
