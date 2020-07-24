// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace ITQJ.OAuth
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("itqj_api", "ITQJ.API"),
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("itqj_api", "ITQJ.API")
                {
                    UserClaims = new[]
                    {
                        "email",
                        "phone",
                        //"role"
                    }
                }
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

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        "itqj_api"
                    }
                },

                new Client
                {
                    ClientId = "itqj_code_web_client",
                    ClientName = "ITQJ-WebClient",
                    ClientSecrets = { new Secret("AAE3727D-88FA-44B8-B406-0CA2AE75C7C3".Sha256()) },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 43200,

                    AllowedGrantTypes = GrantTypes.Code,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    RequireConsent = true,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        //"role",
                        "itqj_api",
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },

                    RedirectUris = new[] { "https://localhost:44348/signin-oidc" },
                    FrontChannelLogoutUri = new string("https://localhost:44348/signout-oidc"),
                    PostLogoutRedirectUris = { "https://localhost:44348/signout-callback-oidc" },
                    AllowAccessTokensViaBrowser = true
                },

                new Client
                {
                    ClientId = "itqj_hybrid_web_client",
                    ClientName = "ITQJ-WebClient",
                    ClientSecrets = { new Secret("AAE3727D-88FA-44B8-B406-0CA2AE75C7C3".Sha256()) },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 43200,

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    RequireConsent = true,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        //"role",
                        "itqj_api",
                        IdentityServerConstants.StandardScopes.OfflineAccess
                    },

                    RedirectUris = new[] { "https://localhost:44348/signin-oidc" },
                    FrontChannelLogoutUri = new string("https://localhost:44348/signout-oidc"),
                    PostLogoutRedirectUris = { "https://localhost:44348/signout-callback-oidc" },
                    AllowAccessTokensViaBrowser = true
                },

                new Client
                {
                    ClientId = "itqj_implicit_web_client",
                    ClientName = "ITQJ-WebClient-Implicit",
                    ClientSecrets = { new Secret("AAE3727D-88FA-44B8-B406-0CA2AE75C7C3".Sha256()) },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 43200,

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequireConsent = true,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        //"role",
                        IdentityServerConstants.StandardScopes.Phone,
                        "itqj_api"
                    },

                    RedirectUris = new[] { "https://localhost:44348/signin-oidc" },
                    FrontChannelLogoutUri = new string("https://localhost:44348/signout-oidc"),
                    PostLogoutRedirectUris = { "https://localhost:44348/signout-callback-oidc" },
                    AllowAccessTokensViaBrowser = true
                }
            };

        public static IEnumerable<TestUser> Users =>
            new TestUser[]
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "jeffrey",
                    Password = "password",

                    Claims = new Claim[]  {
                        new Claim("scope", "itqj_api"),
                        new Claim("email", "jeffreyissaul@hotmail.com"),
                        new Claim("phone", "+1(849)586-7932"),
                        //new Claim("role", "rol_profesional")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "luis",
                    Password = "password",

                    Claims = new Claim[]  {
                        new Claim("scope", "itqj_api"),
                        new Claim("email", "luiseduardofrias27@gmail.com"),
                        new Claim("phone", "+1(849)228-0058"),
                        //new Claim("role", "rol_contratista")
                    }
                }
            };
    }
}