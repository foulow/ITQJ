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
    public class ReviewController : BaseController
    {
        public ReviewController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        [Authorize]
        public async Task<IActionResult> Index(int pageIndex = 1, int maxResults = 5)
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Desconosido")
                return PageNotFound();

            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 5) ? "5" : (maxResults > 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount },
                { "role", userCredentials.Role }
            };

            var pendingReviews = await CallApiGETAsync<ReviewsToMakeVM>(uri: "/api/reviews/pending/" + userCredentials.Id.ToString() + QueryString.Create(queryResult), isSecured: true);

            if (pendingReviews == null)
            {
                pendingReviews = new ReviewsToMakeVM();
                pendingReviews.ProjectsToReview = new List<ProjectResponseDTO>();
                pendingReviews.PageIndex = pageIndex;
            }
            pendingReviews.Review = new ReviewCreateVM();

            return View(pendingReviews);
        }

        [Authorize]
        public async Task<IActionResult> MyReviews(int pageIndex = 1, int maxResults = 5)
        {
            var userCredentials = GetUserCredentials();

            if (userCredentials is null || userCredentials.Role == "Desconosido")
                return PageNotFound();

            var userReviews = await GetReviews(userCredentials.Id.ToString(), pageIndex, maxResults);

            if (userReviews == null)
            {
                userReviews = new ReviewListVM();
                userReviews.PageIndex = pageIndex;
            }

            return View(userReviews);
        }

        [Authorize]
        public async Task<IActionResult> ProfesionalReviews(string userId, int pageIndex = 1, int maxResults = 5)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials.Role != "Contratista")
                return RedirectToAction("AccessDenied", "Authorization");

            var profesionalReviews = await GetReviews(userId, pageIndex, maxResults);

            if (profesionalReviews == null)
            {
                profesionalReviews = new ReviewListVM();
                profesionalReviews.PageIndex = pageIndex;
            }

            return View(profesionalReviews);
        }

        [Authorize]
        public async Task<IActionResult> ContratistReviews(string userId, int pageIndex = 1, int maxResults = 5)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return PageNotFound();

            var userCredentials = GetUserCredentials();

            if (userCredentials.Role != "Profesional")
                return RedirectToAction("AccessDenied", "Authorization");

            var contratistReviews = await GetReviews(userId, pageIndex, maxResults);

            if (contratistReviews == null)
            {
                contratistReviews = new ReviewListVM();
                contratistReviews.PageIndex = pageIndex;
            }

            return View(contratistReviews);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostReviews(ReviewsToMakeVM reviewData)
        {
            if(!ModelState.IsValid)
                return RedirectToAction("Index", reviewData);

            var newReview = (ReviewResponseDTO)reviewData.Review;

            var reviewResponse = await CallApiPOSTAsync<ReviewResponseDTO>(uri: "/api/reviews/", body: newReview, isSecured: true);

            if (reviewResponse is null)
                return RedirectToAction("Index", reviewData);

            var updatePostulant = new PostulantUpdateDTO
            {
                IsSelected = true,
                HasWorkReview = (reviewData.Review.ReviewerRole == "Contratista"),
                HasProyectReview = (reviewData.Review.ReviewerRole == "Profesional")
            };
            
            var postulantResponse = await CallApiPUTAsync<PostulantUpdateDTO>(
                uri: "api/postulants/" + reviewData.Review.PostulantId, body: updatePostulant, isSecured: true);

            return RedirectToAction("Index");
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

            return CallApiGETAsync<ReviewListVM>(uri: "/api/reviews/" + userId + QueryString.Create(queryResult), isSecured: true);
        }
    }
}
