using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class ReviewController : BaseController
    {
        public ReviewController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userCredentials = GetUserCredentials();

            var userReviews = await GetReviews(userCredentials.Id.ToString());

            return View(userReviews);
        }

        [Authorize]
        public async Task<IActionResult> GetProfesionalReviews(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials.Role != "Contratista")
                return RedirectToAction("AccessDenied", "Authorization");

            var userReviews = await GetReviews(userId);

            return View(userReviews);
        }

        private Task<ReviewListVM> GetReviews(string userId)
        {
            return CallSecuredApiGETAsync<ReviewListVM>("/api/reviews/" + userId);
        }
    }
}
