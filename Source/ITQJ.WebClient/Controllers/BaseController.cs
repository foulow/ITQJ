using AutoMapper;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly HttpClient _client;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;
        protected readonly IOptionsMonitor<ClientCredentials> _clientConfiguration;

        public BaseController(IServiceProvider serviceProvider)
        {
            this._client = serviceProvider.GetRequiredService<HttpClient>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
            this._configuration = serviceProvider.GetRequiredService<IConfiguration>();
            this._clientConfiguration = serviceProvider.GetRequiredService<IOptionsMonitor<ClientCredentials>>();
        }

        protected async Task<T> CallApiGETAsync<T>(string uri, bool needJWT = false) where T : class
        {
            if (needJWT)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            T result = null;
            var content = await this._client.GetStringAsync(_configuration["APIURL"] + uri);

            if (content != null || content.Contains("result"))
            {
                var jsonObject = JObject.Parse(content);
                result = jsonObject["result"].ToObject<T>();
            }

            return result;
        }

        protected async Task<T> CallApiPOSTAsync<T>(string uri, T body, bool needJWT = false) where T : class
        {
            if (needJWT)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            T result = null;

            var content = await this._client
                .PostAsync(_configuration["APIURL"] + uri,
                new StringContent(JsonConvert.SerializeObject(body),
                    Encoding.UTF8, "application/json"));

            var response = await content.Content.ReadAsStringAsync();

            if (content != null || response.Contains("result"))
            {
                var jsonObject = JObject.Parse(response);
                result = jsonObject["result"].ToObject<T>();
            }

            return result;
        }

        protected async Task<T> CallApiPUTAsync<T>(string uri, T body) where T : class
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            T result = null;

            var content = await this._client
                .PostAsync(_configuration["APIURL"] + uri,
                new StringContent(JsonConvert.SerializeObject(body),
                    Encoding.UTF8, "application/json"));

            var response = await content.Content.ReadAsStringAsync();

            if (content != null || response.Contains("result"))
            {
                var jsonObject = JObject.Parse(response);
                result = jsonObject["result"].ToObject<T>();
            }

            return result;
        }

        protected async Task<bool> CallApiDELETEAsync(string uri)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var content = await this._client.DeleteAsync(_configuration["APIURL"] + uri);

            return content.StatusCode == HttpStatusCode.OK;
        }

        public IActionResult PageNotFound()
        {
            return View(nameof(PageNotFound));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
