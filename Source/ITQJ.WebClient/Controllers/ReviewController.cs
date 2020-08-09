using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

            if (userCredentials is null || userCredentials.Role == "Desconosido")
                return PageNotFound();

            var queryResult = new Dictionary<string, string>
            {
                { "role", userCredentials.Role }
            };

            var pendingReviews = await CallSecuredApiGETAsync<ReviewsToMakeVM>("/api/reviews/pending/" + userCredentials.Id.ToString() + QueryString.Create(queryResult));

            return View(pendingReviews);
        }

        [Authorize]
        public async Task<IActionResult> MyReviews(int pageIndex = 1, int maxResults = 5)
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Desconosido")
                return PageNotFound();

            var userReviews = await GetReviews(userCredentials.Id.ToString(), pageIndex, maxResults);

            return View(userReviews);
        }

        [Authorize]
        public async Task<IActionResult> GetProfesionalReviews(string userId, int pageIndex = 1, int maxResults = 5)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials.Role != "Contratista")
                return RedirectToAction("AccessDenied", "Authorization");

            var userReviews = await GetReviews(userId, pageIndex, maxResults);

            return View(userReviews);
        }

        private Task<ReviewListVM> GetReviews(string userId, int pageIndex, int maxResults)
        {
            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 5) ? "5" : (maxResults > 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount }
            };

            return CallSecuredApiGETAsync<ReviewListVM>("/api/reviews/" + userId + QueryString.Create(queryResult));
        }
    }
}
