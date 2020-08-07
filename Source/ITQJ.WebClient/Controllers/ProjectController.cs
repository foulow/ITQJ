using ITQJ.Domain.DTOs;
using ITQJ.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class ProjectController : BaseController
    {
        public ProjectController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<IActionResult> Index(string projectId)
        {
            var projectInfo = await CallApiGETAsync<ProjectResponseDTO>("/api/projects/" + projectId);
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if (projectInfo == null)
            {
                return PageNotFound();
            }

            return View(projectInfo);
        }


        [Authorize(Roles = "Contratista")]
        public IActionResult Publish()
        {
            return View(new ProjectResponseDTO());
        }


        [HttpPost]
        public IActionResult Publish(Project project)
        {
            return View();
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostPostulants(string projectId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            var newPostulant = new PostulantCreateDTO
            {
                ProjectId = Guid.Parse(projectId),
                UserId = Guid.Parse(userId)
            };

            var repuesta = await CallSecuredApiPOSTAsync<PostulantCreateDTO>("/api/postulants/", newPostulant);

            if (repuesta.Equals(null))
            {
                ViewBag.ErrorMesseger = "Error al Postularte. \n Reintente.";

                return View();
            }

            return RedirectToAction("Index", new { projectId = projectId });
        }

    }
}
