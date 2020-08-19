using ITQJ.Domain.DTOs;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class PostulantController : BaseController
    {
        public PostulantController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [Authorize]
        public async Task<IActionResult> MyPostulations(int pageIndex = 1, int maxResults = 5)
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role != "Profesional")
                return PageNotFound();

            var myPostulations = await GetPostulations(userCredentials.Id.ToString(), pageIndex, maxResults);

            if (myPostulations == null)
            {
                myPostulations = new PostutantListVM();
                myPostulations.PageIndex = pageIndex;
            }

            return View(myPostulations);
        }

        private Task<PostutantListVM> GetPostulations(string userId, int pageIndex, int maxResults)
        {
            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 5) ? "5" : (maxResults > 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount }
            };

            return CallApiGETAsync<PostutantListVM>(uri: "api/postulants/mypostulations/" + userId + QueryString.Create(queryResult), isSecured: true);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SelectProfesional(Guid postulanId,Guid proyectId)
        {
            PostulantUpdateDTO postulantData = new PostulantUpdateDTO();

            if(!ModelState.IsValid)
            {
                return View(postulantData);
            }

            postulantData.IsSellected = true;

            var response = await CallApiPUTAsync<PostulantUpdateDTO>(
                uri: "api/Postulants/" + postulanId,body: postulantData, isSecured: true);


            return RedirectToAction("Index","Project",new { projectId = proyectId });

        }
    }
}
