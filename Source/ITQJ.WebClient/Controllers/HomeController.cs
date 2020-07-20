using ITQJ.WebClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #region Test Functions.
        // Unprotected.
        public async Task<IActionResult> GetRoles()
        {
            return await CallApiGetMethod("https://localhost:44338/api/roles/");
        }
        public async Task<IActionResult> GetSkills()
        {
            return await CallApiGetMethod("https://localhost:44338/api/skills/");
        }
        public async Task<IActionResult> GetDocumentTypes()
        {
            return await CallApiGetMethod("https://localhost:44338/api/documentTypes/");
        }
        // Require access.
        public async Task<IActionResult> GetUserInfo(string userName)
        {
            return await CallApiGetMethod("https://localhost:44338/api/users?userName=" + userName,
                needJWT: true);
        }
        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
