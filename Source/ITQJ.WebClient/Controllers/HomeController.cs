using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<IActionResult> Index(int pageIndex = 1, int maxResults = 20)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userCredentials = await EnsureUserCreated();
                if (userCredentials.Role == "Desconosido")
                    return RedirectToRoute(new { controller = "User", action = "Register", userName = userCredentials.Email });

                ViewBag.UserId = userCredentials.Id;
                ViewBag.UserName = userCredentials.Email.Split("@").First();
                ViewBag.UserRole = userCredentials.Role;
                ViewBag.UserEmail = userCredentials.Email;
            }

            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 20) ? "20" : (maxResults < 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount }
            };

            var projects = await CallApiGETAsync<ProjectVM>("/api/projects/" + QueryString.Create(queryResult));

            return View(projects);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}