using AutoMapper;
using IdentityModel.Client;
using ITQJ.Domain.DTOs;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Globalization;
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
        protected readonly IOptionsMonitor<ClientCredentialsM> _clientConfiguration;

        public BaseController(IServiceProvider serviceProvider)
        {
            this._client = serviceProvider.GetRequiredService<HttpClient>();
            this._mapper = serviceProvider.GetRequiredService<IMapper>();
            this._configuration = serviceProvider.GetRequiredService<IConfiguration>();
            this._clientConfiguration = serviceProvider.GetRequiredService<IOptionsMonitor<ClientCredentialsM>>();
        }

        protected async Task<T> CallApiGETAsync<T>(string uri, bool needJWT = false) where T : class
        {
            if (needJWT)
            {
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            T result = null;
            var content = await this._client.GetStringAsync(_configuration["APIURL"] + uri);

            if (content != null && content.Contains("result"))
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
                var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
                this._client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            T result = null;

            var content = await this._client
                .PostAsync(_configuration["APIURL"] + uri,
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

        protected async Task<T> CallApiPUTAsync<T>(string uri, T body) where T : class
        {
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
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
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
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

        protected async Task<Guid> GetUserIdByName(string userName)
        {
            var user = await CallApiGETAsync<UserResponseDTO>("/api/users/" + userName);
            if (user == null)
                return Guid.Empty;

            return user.Id;
        }

        public async Task LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
        }

        [Authorize]
        public async Task<IActionResult> LogIn()
        {
            // If enabled allow re-access with refresh token.
            await RefreshTokensAsync();

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        private async Task RefreshTokensAsync()
        {
            var clientCredentials = this._clientConfiguration.CurrentValue;

            var response = await this._client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = clientCredentials.Authority + "/connect/token",

                ClientId = clientCredentials.ClientId,
                ClientSecret = clientCredentials.ClientSecret,

                Scope = clientCredentials.APIName
            });

            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var tokenResponse = await this._client
                .RequestRefreshTokenAsync(new RefreshTokenRequest()
                {
                    RefreshToken = refreshToken,
                });

            var identityToken = await HttpContext.GetTokenAsync("id_token");

            var expiresAt = DateTime.UtcNow + TimeSpan.FromSeconds(tokenResponse.ExpiresIn);

            var tokens = new[]
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.IdToken,
                    Value = identityToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = tokenResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = tokenResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = "expires_at",
                    Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                }
            };

            var authenticationInformation = await HttpContext.AuthenticateAsync("Cookies");

            authenticationInformation.Properties.StoreTokens(tokens);

            await HttpContext.SignInAsync("Cookies",
                authenticationInformation.Principal,
                authenticationInformation.Properties);
        }
    }
}
