using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class PostulantController : BaseController
    {
        public PostulantController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [Authorize]
        public async Task<IActionResult> MyPostulations()
        {
            var userCredentials = GetUserCredentials();

            var myPostulations = await GetMyPostulations(userCredentials.Id.ToString());

            return View(myPostulations);
        }

        private Task<PostutantListVM> GetMyPostulations(string userId)
        {
            return CallSecuredApiGETAsync<PostutantListVM>("api/postulants/mypostulations/" + userId);
        }
    }
}
