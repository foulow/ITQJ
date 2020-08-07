using Microsoft.AspNetCore.Mvc;
using System;

namespace ITQJ.WebClient.Controllers
{
    public class AuthorizationController : BaseController
    {
        public AuthorizationController(IServiceProvider serviceProvider) : base(serviceProvider) { }
        public IActionResult AccessDenied()
        {
            if (!User.Identity.IsAuthenticated)
                GetUserCredentials();

            return View();
        }
    }
}
