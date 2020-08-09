using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
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
            if (string.IsNullOrWhiteSpace(projectId))
                return PageNotFound();

            if (User.Identity.IsAuthenticated)
                GetUserCredentials();

            var projectInfo = await CallApiGETAsync<ProjectResponseDTO>("/api/projects/" + projectId);
            var userId = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            if (projectInfo == null)
                return PageNotFound();

            return View(projectInfo);
        }



        public IActionResult Publish()
        {
            return View(new ProjectResponseDTO());
        }


        [Authorize]
        [HttpPost]
        public IActionResult Publish(Project project)
        {

            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Contratista")
                return PageNotFound();

            return View();
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostPostulants(string projectId)
        {
            var userCredentials = GetUserCredentials();

            var newPostulant = new PostulantCreateDTO
            {
                ProjectId = Guid.Parse(projectId),
                UserId = userCredentials.Id
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
