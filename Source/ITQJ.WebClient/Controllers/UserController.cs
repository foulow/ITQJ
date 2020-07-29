using IdentityModel.Client;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ITQJ.WebClient.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<IActionResult> Register()
        {
            var user = new UserVM();
            user.Roles = await GetRoles();

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserVM user)
        {
            if (!ModelState.IsValid)
            {
                user.Roles = await GetRoles();
                return View(user);
            }

            var newuser = await CallApiPOSTAsync<UserVM>("/api/users/", user, true);

            return RedirectToAction("LogIn");
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

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        private async Task<List<RolVM>> GetRoles()
        {
            return await CallApiGETAsync<List<RolVM>>("/api/roles");
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
