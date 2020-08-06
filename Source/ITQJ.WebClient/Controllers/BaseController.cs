using AutoMapper;
using ITQJ.Domain.DTOs;
using ITQJ.WebClient.Models;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Serilog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceProvider _serviceProvider;
        //protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IHttpClientFactory _clientFactory;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _configuration;
        protected readonly IOptionsMonitor<ClientCredentialsM> _clientConfiguration;

        public BaseController(IServiceProvider serviceProvider)
        {
            //this._httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            this._clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
            this._configuration = serviceProvider.GetRequiredService<IConfiguration>();
            this._clientConfiguration = serviceProvider.GetRequiredService<IOptionsMonitor<ClientCredentialsM>>();
        }

        protected async Task<T> CallApiGETAsync<T>(string uri) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("APIClient");

            T result = null;
            var content = await apiClient.GetStringAsync(uri);

            if (content != null && content.Contains("result"))
            {
                var jsonObject = JObject.Parse(content);
                result = jsonObject["result"].ToObject<T>();
            }

            return result;
        }

        protected async Task<T> CallSecuredApiGETAsync<T>(string uri) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("SecuredAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"].ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return null;
            }

            throw new Exception("Problem accessing the API");
        }

        protected async Task<T> CallApiPOSTAsync<T>(string uri, T body) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("APIClient");

            T result = null;

            var content = await apiClient
                .PostAsync(uri,
                new StringContent(JsonConvert.SerializeObject(body),
                    Encoding.UTF8, "application/json"));

            var response = await content.Content.ReadAsStringAsync();

            if (content != null && response.Contains("result"))
            {
                var jsonObject = JObject.Parse(response);
                result = jsonObject["result"].ToObject<T>();
            }

            return result;
        }

        protected async Task<T> CallSecuredApiPOSTAsync<T>(string uri, T body) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("SecuredAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            T result = null;
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);
                if (jsonObject.ContainsKey("result"))
                    result = jsonObject["result"].ToObject<T>();
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                return null;
            }

            throw new Exception("Problem accessing the API");
        }

        protected async Task<T> CallApiPUTAsync<T>(string uri, T body) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("APIClient");

            T result = null;

            var content = await apiClient
                .PutAsync(uri,
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

        protected async Task<T> CallSecuredApiPUTAsync<T>(string uri, T body) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("SecuredAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Put, uri);
            request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            T result = null;
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);
                if (jsonObject.ContainsKey("result"))
                    result = jsonObject["result"].ToObject<T>();
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                return null;
            }

            throw new Exception("Problem accessing the API");
        }

        protected async Task<bool> CallApiDELETEAsync(string uri)
        {
            var apiClient = this._clientFactory.CreateClient("APIClient");

            var content = await apiClient.DeleteAsync(uri);

            return content.StatusCode == HttpStatusCode.OK;
        }

        protected async Task<bool> CallSecuredApiDELETEAsync<T>(string uri)
        {
            var apiClient = this._clientFactory.CreateClient("SecuredAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            return response.IsSuccessStatusCode;
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

        [Authorize]
        public async Task LogOut(string returnUrl = "/")
        {
            #region Logout config for Reference Tokens
            //var idpClient = this._clientFactory.CreateClient("IDPClient");

            //var discoveryDocumentResponse = await idpClient.GetDiscoveryDocumentAsync();
            //if (discoveryDocumentResponse.IsError)
            //{
            //    throw new Exception(
            //        "Problem accessing the Discovery endpoint.",
            //        discoveryDocumentResponse.Exception);
            //}

            //var clientCredentials = _clientConfiguration.CurrentValue;

            //var accessTokenRevocationResponse = await idpClient.RevokeTokenAsync(
            //    new TokenRevocationRequest
            //    {
            //        Address = discoveryDocumentResponse.RevocationEndpoint,
            //        ClientId = clientCredentials.ClientId,
            //        ClientSecret = clientCredentials.ClientSecret,
            //        Token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken)
            //    });
            //if (accessTokenRevocationResponse.IsError)
            //{
            //    throw new Exception(accessTokenRevocationResponse.Error);
            //}

            //var refreshTokenRevocationResponse = await idpClient.RevokeTokenAsync(
            //    new TokenRevocationRequest
            //    {
            //        Address = discoveryDocumentResponse.RevocationEndpoint,
            //        ClientId = clientCredentials.ClientId,
            //        ClientSecret = clientCredentials.ClientSecret,
            //        Token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken)
            //    });
            //if (refreshTokenRevocationResponse.IsError)
            //{
            //    throw new Exception(refreshTokenRevocationResponse.Error);
            //}
            #endregion

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties
            {
                // Indicate here where Auth0 should redirect the user after a logout.
                // Note that the resulting absolute Uri must be whitelisted in the 
                // **Allowed Logout URLs** settings for the client.
                //RedirectUri = Url.Action("Index", "Home")
                RedirectUri = returnUrl
            });

            //return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        //[Authorize]
        public async Task LogIn(string returnUrl = "/")
        {
            await HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = returnUrl });

            // Get the currently authorized user claims information.
            //var userInfo = await GetUserInfo();
            //return RedirectToRoute(new { controller = "Home", action = "Index" });



        }

        protected async Task<UserResponseDTO> EnsureUserCreated()
        {
            var userCredentials = await CallSecuredApiGETAsync<UserResponseDTO>("/api/users");
            if (userCredentials.Role == "Desconosido")
            {
                return userCredentials;
            }

            var id = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

            var idp_access_token = await CallSecuredApiGETAsync<string>("/api/Auth0Access");

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
    }
}
