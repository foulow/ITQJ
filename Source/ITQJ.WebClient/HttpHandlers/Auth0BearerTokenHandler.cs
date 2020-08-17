using IdentityModel.Client;
using ITQJ.WebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json.Linq;
using RestSharp;
using Serilog;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ITQJ.WebClient.HttpHandlers
{
    public class Auth0BearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        protected readonly IOptionsMonitor<ClientCredentialsM> _clientConfiguration;


        public Auth0BearerTokenHandler(IHttpContextAccessor httpContextAccessor,
            IHttpClientFactory httpClientFactory,
            IOptionsMonitor<ClientCredentialsM> clientConfiguration)
        {
            _httpContextAccessor = httpContextAccessor ??
                throw new ArgumentNullException(nameof(httpContextAccessor));

            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));

            this._clientConfiguration = clientConfiguration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await GetAccessTokenAsync();

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                await _httpContextAccessor.HttpContext.ChallengeAsync("Auth0", new AuthenticationProperties() { RedirectUri = "/" });
            }
            else
            {
                request.SetBearerToken(accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var expiresAt = await _httpContextAccessor
                .HttpContext.GetTokenAsync("expires_at");
            if (string.IsNullOrWhiteSpace(expiresAt))
                expiresAt = await _httpContextAccessor.HttpContext.GetTokenAsync("expires_in");

            if (string.IsNullOrWhiteSpace(expiresAt))
            {
                return "";
            }

            Log.Information(expiresAt);
            var expiresAtDataTimeOffset =
                DateTimeOffset.Parse(expiresAt, CultureInfo.InvariantCulture);

            if ((expiresAtDataTimeOffset.AddSeconds(-60)).ToUniversalTime() > DateTime.UtcNow)
            {
                return await _httpContextAccessor
                    .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            }

            var refreshToken = await _httpContextAccessor
                .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return "";
            }


            var clientCredentials = _clientConfiguration.CurrentValue;
            var clientAccess = new RestClient($"{clientCredentials.Authority}/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=refresh_token&client_id={clientCredentials.ClientId}&client_secret={clientCredentials.ClientSecret}&refresh_token={refreshToken}", ParameterType.RequestBody);
            IRestResponse response = clientAccess.Execute(request);
            var jsonResponse = JObject.Parse(response.Content);


            var timeLeft = new DateTimeOffset();
            timeLeft.AddSeconds((double)int.Parse(jsonResponse["expires_in"].Value<string>()));
            var currentDate = DateTime.UtcNow;
            var expiresIn = new DateTime(timeLeft.Ticks + currentDate.Ticks);

            var updatedTokens = new AuthenticationToken[]
                {
                        new AuthenticationToken
                        {
                            Name = OpenIdConnectParameterNames.IdToken,
                            Value = jsonResponse["id_token"].Value<string>()
                        },
                        new AuthenticationToken
                        {
                            Name = OpenIdConnectParameterNames.AccessToken,
                            Value = jsonResponse["access_token"].Value<string>()
                        },
                        new AuthenticationToken
                        {
                            Name = OpenIdConnectParameterNames.RefreshToken,
                            Value = refreshToken
                        },
                        new AuthenticationToken
                        {
                            Name = "expires_at",
                            Value = expiresIn.ToString("o", CultureInfo.InvariantCulture)
                        }
                };


            var currentAuthenticationResult = await _httpContextAccessor
                .HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            currentAuthenticationResult.Properties.StoreTokens(updatedTokens);

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                currentAuthenticationResult.Principal,
                currentAuthenticationResult.Properties);


            return jsonResponse["access_token"].Value<string>();
        }
    }
}
