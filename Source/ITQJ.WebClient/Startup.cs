using Auth0.AspNetCore.Authentication;
using AutoMapper;
using FluentValidation.AspNetCore;
using ITQJ.Domain.Validations;
using ITQJ.WebClient.HttpHandlers;
using ITQJ.WebClient.Hubs;
using ITQJ.WebClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace ITQJ.WebClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            services.AddControllersWithViews()
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblyContaining
                        <UserCreateDTOValidation>());

            services.AddCors(options =>
                {
                    options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowAnyOrigin();
                        });
                });

            var apiURL = Configuration["APIURL"];

            services.AddHttpClient("SecuredAPIClient", client =>
                {
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Accept, "application/json");
                })
                // OpenIdConnect Configuration Method.
                //.AddHttpMessageHandler<IdentityServerBearerTokenHandler>();
                // Auth0 Configuration Method.
                .AddHttpMessageHandler<Auth0BearerTokenHandler>();

            services.AddHttpClient("APIClient", client =>
                {
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Accept, "application/json");
                });

            services.AddSignalR();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();
            services.AddTransient<HttpContextAccessor>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Auth0 client configuration.
            var idpURL = Configuration["ClientConfiguration:Auth0:Authority"];
            services.AddHttpClient("IDPClient", client =>
                {
                    client.BaseAddress = new Uri(idpURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.Accept, "application/json");
                });
            services.AddTransient<Auth0BearerTokenHandler>();
            services.Configure<ClientCredentialsM>(Configuration.GetSection("ClientConfiguration:Auth0"));
            var scopes = Configuration.GetSection("ClientConfiguration:Auth0:AllowedScopes").GetChildren();

            // OpenIdConnect Configuration Method.
            //services.AddAuthentication(options =>
            //    {
            //        // IdentityServer client configuration.
            //        //options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        //options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //        //options.DefaultChallengeScheme = "oidc";
            //        options.DefaultChallengeScheme = "Auth0";

            //        // Auth0 client configuration.
            //        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    })
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            //    {
            //        options.AccessDeniedPath = "/Authorization/AccessDenied";
            //    })
            //.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            //{
            //    // General client configuration.
            //    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.SaveTokens = true;
            //    foreach (var scope in scopes)
            //    {
            //        options.Scope.Add(scope.Value);
            //    }

            //    // Auth0 client configuration.
            //    options.Authority = Configuration["ClientConfiguration:Auth0:Authority"];
            //    options.CallbackPath = new PathString("/signin-auth0");
            //    options.ClaimsIssuer = "Auth0";
            //    options.RequireHttpsMetadata = false;
            //    options.ClientId = Configuration["ClientConfiguration:Auth0:ClientId"];
            //    options.ClientSecret = Configuration["ClientConfiguration:Auth0:ClientSecret"];
            //    options.ResponseType = "code";
            //    options.ClaimActions.MapUniqueJsonKey("role", "role");
            //    options.ClaimActions.MapUniqueJsonKey("email", "email");
            //    options.ClaimActions.MapUniqueJsonKey("name", "name");
            //    options.Events = new OpenIdConnectEvents
            //    {
            //        OnRedirectToIdentityProvider = context =>
            //        {
            //            context.ProtocolMessage.SetParameter("audience",
            //                Configuration["ClientConfiguration:Auth0:Audience"]);

            //            return Task.CompletedTask;
            //        },
            //        // handle the logout redirection 
            //        OnRedirectToIdentityProviderForSignOut = (context) =>
            //        {
            //            var logoutUri = $"{Configuration["ClientConfiguration:Auth0:Authority"]}/v2/logout?client_id={Configuration["ClientConfiguration:Auth0:ClientId"]}";

            //            var postLogoutUri = context.Properties.RedirectUri;
            //            if (!string.IsNullOrEmpty(postLogoutUri))
            //            {
            //                if (postLogoutUri.StartsWith("/"))
            //                {
            //                    // transform to absolute
            //                    var request = context.Request;
            //                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
            //                }
            //                logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
            //            }

            //            context.Response.Redirect(logoutUri);
            //            context.HandleResponse();

            //            return Task.CompletedTask;
            //        }
            //    };
            //});

            // Auth0 Configuration Method.
            services.AddAuth0WebAppAuthentication(options =>
            {
                options.Domain = Configuration["ClientConfiguration:Auth0:Domain"];
                options.CallbackPath = new PathString("/signin-auth0");
                options.ClientId = Configuration["ClientConfiguration:Auth0:ClientId"];
                options.ClientSecret = Configuration["ClientConfiguration:Auth0:ClientSecret"];
                options.ResponseType = "code";
                options.Scope = "openid profile email name roles offline_access itqj_api";
                options.OpenIdConnectEvents = new OpenIdConnectEvents
                {
                    OnRedirectToIdentityProvider = context =>
                    {
                        context.ProtocolMessage.SetParameter("audience",
                            Configuration["ClientConfiguration:Auth0:Audience"]);

                        return Task.CompletedTask;
                    },
                    // handle the logout redirection 
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"{Configuration["ClientConfiguration:Auth0:Authority"]}/v2/logout?client_id={Configuration["ClientConfiguration:Auth0:ClientId"]}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // transform to absolute
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    }
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "*/*";

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is Exception ex)
                        {
                            await Task.Run(() =>
                            {
                                Log.Fatal("Server-side Error: {0}", ex.Message);
                            });
                        }
                    });
                });
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();

#if !DEBUG
            app.UseHttpsRedirection();
#endif

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "allLinks",
                    pattern: "{*a}",
                    defaults: new { controller = "Home", action = "PageNotFound" });

                endpoints.MapHub<ChatHub>("/chatHub");
            });

        }
    }
}
