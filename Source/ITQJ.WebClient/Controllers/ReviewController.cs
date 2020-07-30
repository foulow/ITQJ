using Microsoft.AspNetCore.Mvc;
using System;

namespace ITQJ.WebClient.Controllers
{
    public class ReviewController : BaseController
    {
        public ReviewController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
