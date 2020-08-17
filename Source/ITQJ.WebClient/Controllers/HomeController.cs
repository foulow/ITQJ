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

        public async Task<IActionResult> Index(int pageIndex = 1, int maxResults = 5)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userCredentials = await EnsureUserCreated();
                if (userCredentials is null || userCredentials.Role == "Desconosido")
                    return RedirectToAction("Register", "User");

                ViewBag.UserId = userCredentials.Id;
                ViewBag.UserName = userCredentials.Email.Split("@").First();
                ViewBag.UserRole = userCredentials.Role;
                ViewBag.UserEmail = userCredentials.Email;
            }

            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 5) ? "5" : (maxResults > 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount }
            };

            var projects = await CallApiGETAsync<ProjectListVM>(uri: "/api/projects/" + QueryString.Create(queryResult), isSecured: false);

            if (projects == null)
            {
                projects = new ProjectListVM();
                projects.PageIndex = pageIndex;
            }

            return View(projects);
        }

        public IActionResult Privacy()
        {
            if (User.Identity.IsAuthenticated)
                GetUserCredentials();

            return View();
        }

        public IActionResult About()
        {
            if (User.Identity.IsAuthenticated)
                GetUserCredentials();

            return View();
        }

        public IActionResult CookiesPolicy()
        {
            if (User.Identity.IsAuthenticated)
                GetUserCredentials();

            return View();
        }

        public IActionResult Donations()
        {
            if (User.Identity.IsAuthenticated)
                GetUserCredentials();

            return View();
        }
    }
}