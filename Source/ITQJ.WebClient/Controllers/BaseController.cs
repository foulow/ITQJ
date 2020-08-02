using AutoMapper;
using IdentityModel.Client;
using ITQJ.WebClient.Models;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"].ToObject<T>();
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

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"].ToObject<T>();
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

        protected async Task<T> CallSecuredApiDELETEAsync<T>(string uri) where T : class
        {
            var apiClient = this._clientFactory.CreateClient("SecuredAPIClient");

            var request = new HttpRequestMessage(HttpMethod.Delete, uri);

            var response = await apiClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(responseString);

                return jsonObject["result"].ToObject<T>();
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized ||
                response.StatusCode == HttpStatusCode.Forbidden)
            {
                return null;
            }

            throw new Exception("Problem accessing the API");
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

        public async Task LogOut()
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
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        [Authorize]
        public async Task<IActionResult> LogIn()
        {
            // Get the currently authorized user claims information.
            var userInfo = await GetUserInfo();

            return RedirectToRoute(new { controller = "Home", action = "Index", userInfoModel = userInfo });
        }

        public async Task<UserInfoM> GetUserInfo()
        {
            var idpClient = this._clientFactory.CreateClient("IDPClient");

            var discoveryDocumentResponse = await idpClient.GetDiscoveryDocumentAsync();
            if (discoveryDocumentResponse.IsError)
            {
                throw new Exception(
                    "Problem accessing the Discovery endpoint.",
                    discoveryDocumentResponse.Exception);
            }

            var accessToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            var userInfoResponse = await idpClient.GetUserInfoAsync(
                new UserInfoRequest
                {
                    Address = discoveryDocumentResponse.UserInfoEndpoint,
                    Token = accessToken
                });

            if (userInfoResponse.IsError)
            {
                throw new Exception(
                    "Problem accessing the UserInfo endpoint.",
                    userInfoResponse.Exception);
            }

            return new UserInfoM
            {
                Id = Guid.Parse(userInfoResponse.Claims.FirstOrDefault(c => c.Type == "sub")?.Value),
                UserName = userInfoResponse.Claims.FirstOrDefault(c => c.Type == "name")?.Value,
                Role = userInfoResponse.Claims.FirstOrDefault(c => c.Type == "role")?.Value
            };
        }
    }
}
