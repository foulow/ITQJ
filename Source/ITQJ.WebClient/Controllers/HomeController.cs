using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ITQJ.WebClient.Models;

namespace ITQJ.WebClient.Controllers
{

    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<IActionResult> Index(UserInfoM userInfoModel,int PageIndex)
        {

            var projects = await CallApiGETAsync<ProjectVM>("/api/projects");


            if (User.Identity.IsAuthenticated)
            {
                if (userInfoModel != null)
                    userInfoModel = await  GetUserInfo();

                ViewBag.UserId = userInfoModel.Id;
                ViewBag.UserName = userInfoModel.UserName;
                ViewBag.Role = userInfoModel.Role;
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