using AutoMapper;
using IdentityModel;
using ITQJ.WebClient.HttpHandlers;
using ITQJ.WebClient.Hubs;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
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

            services.AddControllersWithViews();

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

            services.AddSignalR();

            services.AddHttpContextAccessor();
            services.AddTransient<BearerTokenHandler>();

            var apiURL = Configuration["APIURL"];
            services.AddHttpClient("SecuredAPIClient", client =>
                {
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                })
                .AddHttpMessageHandler<BearerTokenHandler>();

            services.AddHttpClient("APIClient", client =>
                {
                    client.BaseAddress = new Uri(apiURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                });

            var authorityURL = Configuration["AuthorityURL"];
            services.AddHttpClient("IDPClient", client =>
                {
                    client.BaseAddress = new Uri(authorityURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ClientCredentialsM>(Configuration.GetSection("ClientConfiguration"));


            var scopes = Configuration.GetSection("ClientConfiguration:AllowedScopes").GetChildren();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; //oidc
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.AccessDeniedPath = "/Authorization/AccessDenied";
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options => //oidc
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = authorityURL;
                    options.ClientId = Configuration["ClientConfiguration:ClientId"];
                    options.ClientSecret = Configuration["ClientConfiguration:ClientSecret"];
                    options.ResponseType = "code";
                    foreach (var scope in scopes)
                    {
                        options.Scope.Add(scope.Value);
                    }
                    options.ClaimActions.MapUniqueJsonKey("email", "email");
                    options.ClaimActions.MapUniqueJsonKey("phone", "phone");
                    options.ClaimActions.MapUniqueJsonKey("role", "role");
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.GivenName,
                        RoleClaimType = JwtClaimTypes.Role
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
            }
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
