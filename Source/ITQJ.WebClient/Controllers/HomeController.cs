using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<IActionResult> Index(int pageIndex = 1, int maxResults = 20)
        {
            string currentPage = (pageIndex < 1) ? "1" : pageIndex.ToString();
            string maxProjectsCount = (maxResults < 20) ? "20" : (maxResults < 100) ? "100" : maxResults.ToString();
            var queryResult = new Dictionary<string, string>
            {
                { nameof(pageIndex), currentPage },
                { nameof(maxResults), maxProjectsCount }
            };

            var projects = await CallApiGETAsync<ProjectVM>("/api/projects/" + QueryString.Create(queryResult));

            if (User.Identity.IsAuthenticated)
            {
                var userInfoModel = await GetUserInfo();

                if (userInfoModel != null)
                {
                    ViewBag.UserId = userInfoModel.Id;
                    ViewBag.UserName = userInfoModel.UserName;
                    ViewBag.Role = userInfoModel.Role;
                }
            }

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