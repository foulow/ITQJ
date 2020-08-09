using ITQJ.Domain.DTOs;
using ITQJ.Domain.Entities;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

            if (projectInfo == null)
                return PageNotFound();

            return View(projectInfo);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Publish()
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role != "Contratista")
                return PageNotFound();

            var newProject = new ProjectResponseDTO();
            newProject.UserId = userCredentials.Id;

            return View(newProject);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Publish(ProjectResponseDTO project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            var newProject = await CallSecuredApiPOSTAsync<ProjectResponseDTO>("/api/projects", project);

            return RedirectToRoute(new { action = "Index", controller = "Project", projectId = newProject.Id });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string projectId)
        {
            if (string.IsNullOrWhiteSpace(projectId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role != "Contratista")
                return PageNotFound();

            var myProyect = await CallSecuredApiGETAsync<ProjectResponseDTO>("api/projects/myprojects/" + projectId);

            if (userCredentials.Id != myProyect.UserId)
                return PageNotFound();

            return View(myProyect);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(ProjectResponseDTO project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }

            var newProject = await CallSecuredApiPUTAsync<ProjectResponseDTO>("/api/projects/myprojects/" + project.Id.ToString(), project);

            if (newProject == null)
                return View(project);

            return RedirectToAction("Edit", new { projectId = newProject.Id.ToString() });
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


        [Authorize]
        public async Task<IActionResult> MyProjects(int pageIndex = 1, int maxResults = 5)
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role != "Contratista")
                return PageNotFound();

            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 5) ? "5" : (maxResults > 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount }
            };

            var projects = await CallApiGETAsync<ProjectListVM>("/api/projects/current/" + userCredentials.Id.ToString() + QueryString.Create(queryResult));

            return View(projects);
        }
    }
}
