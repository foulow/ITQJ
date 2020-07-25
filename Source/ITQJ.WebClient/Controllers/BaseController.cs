using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly HttpClient _client;
        protected readonly IMapper _mapper;
        protected readonly IOptionsMonitor<ClientCredentials> _configuration;
        public BaseController(IServiceProvider serviceProvider)
        {
            this._client = new HttpClient();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
            this._configuration = serviceProvider.GetRequiredService<IOptionsMonitor<ClientCredentials>>();
        }
        protected async Task<IActionResult> CallApiGetMethod(string uri, bool needJWT = false)
        {
            if (needJWT)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var content = await this._client.GetStringAsync(uri);
            ViewBag.Json = JObject.Parse(content).ToString();

            return View("json");
        }
    }
}
