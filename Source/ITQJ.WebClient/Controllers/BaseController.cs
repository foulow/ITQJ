using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<IActionResult> CallApiGetMethod(string uri, bool needJWT = false)
        {
            var client = new HttpClient();
            if (needJWT)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var content = await client.GetStringAsync(uri);
            ViewBag.Json = JObject.Parse(content).ToString();

            return View("json");
        }
    }
}
