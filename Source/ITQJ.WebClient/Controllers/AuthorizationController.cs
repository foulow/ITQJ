using Microsoft.AspNetCore.Mvc;

namespace ITQJ.WebClient.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
