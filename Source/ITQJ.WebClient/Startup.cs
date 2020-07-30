using AutoMapper;
using ITQJ.WebClient.Hubs;
using ITQJ.WebClient.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ITQJ.WebClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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

            services.AddHttpClient("APIClient", client =>
            {
                client.BaseAddress = new Uri(Configuration["APIURL"]);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });
            services.AddTransient<HttpClient>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ClientCredentialsM>(Configuration.GetSection("ClientConfiguration"));

            var authority = Configuration["AuthorityURL"];

            var scopes = Configuration.GetSection("ClientConfiguration:AllowedScopes").GetChildren();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme; //oidc
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options => //oidc
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = authority;
                    options.ClientId = Configuration["ClientConfiguration:ClientId"];
                    options.ClientSecret = Configuration["ClientConfiguration:ClientSecret"];
                    options.ResponseType = "code";
                    foreach (var scope in scopes)
                    {
                        options.Scope.Add(scope.Value);
                    }
                    options.SaveTokens = true;
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
