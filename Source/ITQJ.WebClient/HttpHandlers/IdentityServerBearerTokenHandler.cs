using IdentityModel.Client;
using ITQJ.WebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ITQJ.WebClient.HttpHandlers
{
    public class IdentityServerBearerTokenHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        protected readonly IOptionsMonitor<ClientCredentialsM> _clientConfiguration;


        public IdentityServerBearerTokenHandler(IHttpContextAccessor httpContextAccessor,
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

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.SetBearerToken(accessToken);
            }

            return await base.SendAsync(request, cancellationToken);
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var expiresAt = await _httpContextAccessor
                .HttpContext.GetTokenAsync("expires_at");

            var expiresAtDataTimeOffset =
                DateTimeOffset.Parse(expiresAt, CultureInfo.InvariantCulture);

            if ((expiresAtDataTimeOffset.AddSeconds(-60)).ToUniversalTime() > DateTime.UtcNow)
            {
                return await _httpContextAccessor
                    .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            }

            var idpClient = _httpClientFactory.CreateClient("IDPClient");

            var discoveryResponse = await idpClient.GetDiscoveryDocumentAsync();
            if (discoveryResponse.IsError)
            {
                throw new Exception(
                    "Problem accessing the Discovery endpoint.",
                    discoveryResponse.Exception);
            }

            var clientCredentials = _clientConfiguration.CurrentValue;

            var refreshToken = await _httpContextAccessor
                .HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            var refreshResponse = await idpClient.RequestRefreshTokenAsync(
                new RefreshTokenRequest
                {
                    Address = discoveryResponse.TokenEndpoint,

                    ClientId = clientCredentials.ClientId,
                    ClientSecret = clientCredentials.ClientSecret,
                    Scope = clientCredentials.APIName,

                    RefreshToken = refreshToken
                });

            if (refreshResponse.IsError)
            {
                throw new Exception(
                    "Problem accessing the Token endpoint.",
                    refreshResponse.Exception);
            }

            var updatedTokens = new[]
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.IdToken,
                    Value = refreshResponse.IdentityToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = refreshResponse.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = refreshResponse.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = "expires_at",
                    Value = (DateTime.UtcNow + TimeSpan.FromSeconds(refreshResponse.ExpiresIn))
                        .ToString("o", CultureInfo.InvariantCulture)
                }
            };

            var currentAuthenticationResult = await _httpContextAccessor
                .HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            currentAuthenticationResult.Properties.StoreTokens(updatedTokens);

            await _httpContextAccessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                currentAuthenticationResult.Principal,
                currentAuthenticationResult.Properties);

            return refreshResponse.AccessToken;
        }
    }
}
