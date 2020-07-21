// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace ITQJ.OAuth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("itqj_api", "ITQJ.API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("itqj_api", "ITQJ.API"),
                new ApiResource("rol_profesional", "Profesional"),
                new ApiResource("rol_contratista", "Contratista")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "itqj_web_client",
                    ClientName = "ITQJ-WebClient",
                    ClientSecrets = { new Secret("AAE3727D-88FA-44B8-B406-0CA2AE75C7C3".Sha256()) },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 43200,

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "itqj_api"
                    },

                    RedirectUris = new[]
                    {
                        "https://localhost:44348/signin-oidc"
                    },
                    PostLogoutRedirectUris = { "https://localhost:44348/signout-callback-oidc" }
                },

                new Client
                {
                    ClientId = "itqj_implicit_web_client",
                    ClientName = "ITQJ-WebClient-Implicit",
                    ClientSecrets = { new Secret("AAE3727D-88FA-44B8-B406-0CA2AE75C7C3".Sha256()) },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 43200,

                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "itqj_api"
                    },

                    RedirectUris = new[]
                    {
                        "https://localhost:44348/signin-oidc"
                    },
                    PostLogoutRedirectUris = { "https://localhost:44348/signout-callback-oidc" }
                }
            };

        public static IEnumerable<TestUser> Users =>
            new TestUser[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "jeffrey",
                    Password = "password"
                }
            };
    }
}