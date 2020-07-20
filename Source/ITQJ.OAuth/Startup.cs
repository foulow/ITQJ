// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ITQJ.OAuth
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 44328;
            });

            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();
            services.AddMvc(options => { options.EnableEndpointRouting = false; });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                           ForwardedHeaders.XForwardedProto;
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            });

            //// Use this for in memory data test. (not connection string needed)
            //services.AddIdentityServer(options =>
            //{
            //    // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
            //    options.EmitStaticAudienceClaim = true;
            //})
            //    .AddDeveloperSigningCredential()
            //    .AddTestUsers(Config.Users.ToList())
            //    .AddInMemoryIdentityResources(Config.IdentityResources)
            //    .AddInMemoryApiScopes(Config.ApiScopes)
            //    .AddInMemoryApiResources(Config.ApiResources)
            //    .AddInMemoryClients(Config.Clients);

            // Use this for real db implementation.
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).Assembly.GetName().FullName;
            var builder = services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = true;
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                // this adds the test user root password root to the IDP server.
                .AddTestUsers(Config.Users.ToList())
                // this adds the config data from DB (clients, resources, CORS)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlServer(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                });
            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();
            ////builder.AddSigningCredential(new X509Certificate2(@"C:\Projects\Visual Studio\Pidelo\Repositorios\Pidelo-API\pidelo.pfx", "Paravailarla.1"));
        }

        public void Configure(IApplicationBuilder app)
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

            app.UseHttpsRedirection();

            app.UseForwardedHeaders();

            // uncomment if you want to add MVC
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            // uncomment, if you want to add MVC
            app.UseAuthorization();
            app.UseMvcWithDefaultRoute();
        }
    }
}
