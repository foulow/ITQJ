using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Serilog;
using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth;
using Auth0.AspNetCore.Authentication;

namespace ITQJ.WebClient.Controllers
{
    public class BaseController : Controller
    {
        //protected readonly IServiceProvider _serviceProvider;
        //protected readonly IHttpContextAccessor _httpContextAccessor;
        //protected readonly IMapper _mapper;
        //protected readonly IConfiguration _configuration;
        protected readonly IHttpClientFactory _clientFactory;
        protected readonly IOptionsMonitor<ClientCredentialsM> _clientConfiguration;
        protected readonly IWebHostEnvironment _environment;

#if !DEBUG
        private string _beaseWebURL = "https://localhost:44348";
#else
        private string _beaseWebURL = "http://localhost:5048";
#endif

        public BaseController(IServiceProvider serviceProvider)
        {
            //this._serviceProvider = serviceProvider;
            //this._httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            //this._mapper = serviceProvider.GetRequiredService<IMapper>();
            //this._configuration = serviceProvider.GetRequiredService<IConfiguration>();
            this._clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            this._clientConfiguration = serviceProvider.GetRequiredService<IOptionsMonitor<ClientCredentialsM>>();
            this._environment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
        }

        protected async Task<T> CallApiGETAsync<T>(string uri, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"]?.ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            await GetErrors(response);
            return null;
        }

        protected async Task<T> CallApiPOSTAsync<T>(string uri, T body, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"]?.ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            await GetErrors(response);
            return null;
        }

        protected async Task<T> CallApiPUTAsync<T>(string uri, T body, bool isSecured) where T : class
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"]?.ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            await GetErrors(response);
            return null;
        }

        protected async Task<bool> CallApiDELETEAsync(string uri, bool isSecured)
        {
            var apiClient = this._clientFactory.CreateClient((isSecured) ? "SecuredAPIClient" : "APIClient");

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("Problem accessing the API");
            }

            await GetErrors(response);
            return false;
        }

        protected IActionResult PageNotFound()
        {
            if (User.Identity.IsAuthenticated)
                GetUserCredentials();

            return View(nameof(PageNotFound));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        protected IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public async Task LogOut(string returnUrl = "/")
        {
            var authenticationProperties = new AuthenticationProperties { RedirectUri = Url.Action("Index", "Home") };


            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // OpenIdConnect Configuration Method.
            //await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, authenticationProperties);
            // Auth0 Configuration Method.
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);

        }

        //[Authorize]
        public async Task LogIn(string returnUrl = "/")
        {
            var authenticationProperties = new AuthenticationProperties() { RedirectUri = _beaseWebURL + returnUrl };

            // OpenIdConnect Configuration Method.
            //await HttpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme, authenticationProperties);
            // Auth0 Configuration Method.
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);

            // Get the currently authorized user claims information.
            //var userInfo = await GetUserInfo();
        }

        protected UserResponseDTO GetUserCredentials()
        {
            var userCredentials = GetUserCredentialsAsync()?.Result;
            if (userCredentials is null)
                return new UserResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Email = "visitor@unregister.com",
                    Role = "Desconosido"
                };

            ViewBag.UserId = userCredentials.Id;
            ViewBag.UserName = userCredentials.Email.Split("@").First();
            ViewBag.UserRole = userCredentials.Role;
            ViewBag.UserEmail = userCredentials.Email;

            return userCredentials;
        }

        protected Task<UserResponseDTO> GetUserCredentialsAsync()
        {
            return CallApiGETAsync<UserResponseDTO>(uri: "/api/users", isSecured: true);
        }

        protected async Task<UserResponseDTO> EnsureUserCreated()
        {
            var userCredentials = await GetUserCredentialsAsync();

            if (userCredentials is null)
                return new UserResponseDTO
                {
                    Id = Guid.NewGuid(),
                    Email = "visitor@unregister.com",
                    Role = "Desconosido"
                };

            if (userCredentials.Role == "Desconosido")
            {
                return userCredentials;
            }

            var id = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            var idp_access_token = await CallApiGETAsync<string>(uri: "/api/Auth0Access", isSecured: true);

            var clientCredentials = _clientConfiguration.CurrentValue;
            var client = new RestClient($"{clientCredentials.Authority}/api/v2/users/{id}/roles");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", $"Bearer {idp_access_token}");
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful && response.Content.Length > 7)
            {
                var jsonValues = JArray.Parse(response.Content);

                string role = "";
                foreach (var jsonValue in jsonValues)
                {
                    if ((string)jsonValue["name"] == userCredentials.Role)
                        role += (string)jsonValue["name"];
                }

                if (role != userCredentials.Role)
                {
                    // TODO: Update local roles.
                    Log.Error($"Unexpected result on role maching {role} is not {userCredentials.Role}.");
                }

                return userCredentials;
            }
            else
            {
                var rolesClient = new RestClient($"{clientCredentials.Authority}/api/v2/roles");
                request = new RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json");
                request.AddHeader("Authorization", $"Bearer {idp_access_token}");
                request.AddHeader("cache-control", "no-cache");
                response = rolesClient.Execute(request);

                if (response.IsSuccessful && response.Content.Length > 7)
                {
                    var jsonValues = JArray.Parse(response.Content);

                    string role_id = "";
                    foreach (var jsonValue in jsonValues)
                    {
                        if ((string)jsonValue["name"] == userCredentials.Role)
                            role_id = (string)jsonValue["id"];
                    }

                    request = new RestRequest(Method.POST);
                    request.AddHeader("content-type", "application/json");
                    request.AddHeader("Authorization", $"Bearer {idp_access_token}");
                    request.AddHeader("cache-control", "no-cache");
                    request.AddParameter("application/json", $"{{\"roles\": [ \"{role_id}\" ] }}", ParameterType.RequestBody);
                    response = client.Execute(request);
                }
            }

            return userCredentials;
        }

        private Task GetErrors(HttpResponseMessage httpResponse)
        {
            if (this._environment.EnvironmentName == "Development")
            {
                if (httpResponse.StatusCode == HttpStatusCode.NotFound)
                    ViewBag.ErrorLevel = "alert-warning";

                if (httpResponse.StatusCode == HttpStatusCode.BadRequest || httpResponse.StatusCode == HttpStatusCode.InternalServerError)
                    ViewBag.ErrorLevel = "alert-danger";

                ViewBag.Errors = httpResponse.Content.ReadAsStringAsync().Result;

            }

            return Task.CompletedTask;
        }
    }
}
