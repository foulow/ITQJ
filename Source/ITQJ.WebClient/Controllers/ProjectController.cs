using ITQJ.Domain.DTOs;
using ITQJ.WebClient.ViewModels;
using ITQJ.WebClient.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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

            var projectInfo = await CallApiGETAsync<ProjectResponseDTO>(uri: "/api/projects/" + projectId, isSecured: false);

            if (projectInfo == null)
                return PageNotFound();

            ViewBag.CurrentDate = DateTime.Now;
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

            var newProject = await CallApiPOSTAsync<ProjectResponseDTO>(uri: "/api/projects", body: project, isSecured: true);

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

            var myProyect = await CallApiGETAsync<ProjectResponseDTO>(uri: "api/projects/myprojects/" + projectId, isSecured: true);

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

            var editedProyect = await CallApiPUTAsync<ProjectResponseDTO>(uri: "/api/projects/myprojects/" + project.Id.ToString(), body: project, isSecured: true);

            if (editedProyect == null)
                return View(project);

            return RedirectToAction("Edit", new { projectId = project.Id });
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

            var repuesta = await CallApiPOSTAsync<PostulantCreateDTO>(uri: "/api/postulants/", body: newPostulant, isSecured: true);

            if (repuesta.Equals(null))
            {
                ViewBag.ErrorMesseger = "Error al Postularse. \n Intentelo nuevamente.";

                return RedirectToAction("Index", new { projectId = projectId });
            }

            return RedirectToAction("Index", new { projectId = projectId });
        }

        [Authorize]
        [HttpGet("[action]/{fileName}")]
        public async Task<IActionResult> DownloadMileStone(string fileName)  
        {  
            if (string.IsNullOrWhiteSpace(fileName))  
                return Content("nombre de archivo no existente");  
        
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), Resources.SubDirectory, fileName);  
        
            var memory = new MemoryStream();  
            using (var stream = new FileStream(filePath, FileMode.Open))  
            {  
                await stream.CopyToAsync(memory);
            }  
            memory.Position = 0;  
            
            return File(memory, GetContentType(filePath), Path.GetFileName(filePath));  
        } 

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostMileStone(MileStoneVM milestoneData)
        {
            if (milestoneData.FormFile.Length == 0)
            {
                return RedirectToAction("Index", new { projectId = milestoneData.ProjectId });
            }

            var fileName = $"{Guid.NewGuid()}.{Path.GetFileName(milestoneData.FormFile.FileName).Split(".").Last()}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), Resources.SubDirectory, fileName);

            await using (var stream = System.IO.File.Create(filePath))
            {
                await milestoneData.FormFile.CopyToAsync(stream);
            }

            MileStoneResponseDTO newMileStone = (MileStoneResponseDTO)milestoneData;
            newMileStone.FileName = fileName;
            newMileStone.UploadDate = DateTime.Now;
            var repuesta = await CallApiPOSTAsync<MileStoneResponseDTO>(uri: "/api/mileStone/", body: newMileStone, isSecured: true);

            if (repuesta.Equals(null))
            {
                ViewBag.ErrorMesseger = "Error al enviar la entrega del proyecto. \n Intentelo nuevamente.";

                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);

                return RedirectToAction("Index", new { projectId = milestoneData.ProjectId });
            }

            return RedirectToAction("Index", new { projectId = milestoneData.ProjectId });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CloseProject(ProjectResponseDTO project)
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials.Id != project.UserId)
                return RedirectToAction("AccessDenied", "Authorization");

            var editedProyect = await CallApiPUTAsync<ProjectResponseDTO>(uri: "/api/projects/myprojects/" + project.Id.ToString(), body: project, isSecured: true);

            if (editedProyect == null)
                return RedirectToAction("Index", new { projectId = project.Id });

            return RedirectToAction("Index", new { projectId = project.Id });
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

            var projects = await CallApiGETAsync<ProjectListVM>(uri: "/api/projects/current/" + userCredentials.Id.ToString() + QueryString.Create(queryResult), isSecured: true);

            if (projects == null)
            {
                projects = new ProjectListVM();
                projects.PageIndex = pageIndex;
            }

            return View(projects);
        }

        private string GetContentType(string path)  
        {  
            var types = GetMimeTypes();  
            var ext = Path.GetExtension(path).ToLowerInvariant();  
            return types[ext];  
        }  
   
        private Dictionary<string, string> GetMimeTypes()  
        {  
            return new Dictionary<string, string>  
            {  
                {".txt", "text/plain"},  
                {".pdf", "application/pdf"},  
                {".doc", "application/vnd.ms-word"},  
                {".docx", "application/vnd.ms-word"},  
                {".xls", "application/vnd.ms-excel"},  
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},  
                {".png", "image/png"},  
                {".jpg", "image/jpeg"},  
                {".jpeg", "image/jpeg"},  
                {".gif", "image/gif"},  
                {".csv", "text/csv"},
                {".zip", "application/zip"}
            };  
        }
    }
}
