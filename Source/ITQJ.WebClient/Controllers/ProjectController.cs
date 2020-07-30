using Microsoft.AspNetCore.Mvc;
using System;

namespace ITQJ.WebClient.Controllers
{
    public class ProjectController : BaseController
    {
        public ProjectController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
