using IdentityModel.Client;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }

        public async Task LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");
            await HttpContext.SignOutAsync("oidc");
        }

        [Authorize]
        public IActionResult LogIn()
        {
            // If enabled allow re-access with refresh token.
            // await RefreshTokensAsync();

            return View("About");
        }

        private async Task RefreshTokensAsync()
        {
            var clientCredentials = this._configuration.CurrentValue;

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
        [Authorize]
        public async Task<IActionResult> GetUserInfo(string userName)
        {
            return await CallApiGetMethod("https://localhost:44338/api/users/" + userName,
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
