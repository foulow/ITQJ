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
                new IdentityResources.Phone(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("itqj_api", "ITQJ.API", new List<string> { "role" }),
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
                        "role"
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
                    AccessTokenLifetime = 1800,

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        "itqj_api",
                        "roles"
                    }
                },

                new Client
                {
                    ClientId = "itqj_code_web_client",
                    ClientName = "ITQJ-WebClient",
                    ClientSecrets = { new Secret("AAE3727D-88FA-44B8-B406-0CA2AE75C7C3".Sha256()) },
                    UpdateAccessTokenClaimsOnRefresh = true,
                    AccessTokenLifetime = 1800,

                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "itqj_api",
                        "roles",
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
                    AccessTokenLifetime = 1800,

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "itqj_api",
                        "roles",
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
                    AccessTokenLifetime = 1800,

                    AllowedGrantTypes = GrantTypes.Implicit,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RequirePkce = true,

                    AllowedScopes = new[]
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        "itqj_api",
                        "roles"
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
                    SubjectId = "7A5B3C6E-7E95-435E-B46F-1F449F49BE04",
                    Username = "jeffrey",
                    Password = "password",

                    Claims = new Claim[]  {
                        new Claim("scope", "itqj_api"),
                        new Claim("email", "jeffreyissaul@hotmail.com"),
                        new Claim("phone", "+1(849)586-7932"),
                        new Claim("role", "Profesional")
                    }
                },
                new TestUser
                {
                    SubjectId = "E80F88AF-C61E-4500-A77E-8EDE80538B84",
                    Username = "luis",
                    Password = "password",

                    Claims = new Claim[]  {
                        new Claim("scope", "itqj_api"),
                        new Claim("email", "luiseduardofrias27@gmail.com"),
                        new Claim("phone", "+1(849)228-0058"),
                        new Claim("role", "Contratista")
                    }
                }
            };
    }
}