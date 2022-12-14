using System;
using System.Collections.Generic;
using GameRoundResult.Web.Configuration;
using GameRoundResult.Web.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GameRoundResult.Web
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
            services.Configure<List<AuthenticationClient>>(Configuration.GetSection("AuthenticationClients"));
            services.Configure<List<OperatorConfig>>(Configuration.GetSection("OperatorConfigs"));
            services.Configure<HostConfiguration>(Configuration.GetSection("HostConfiguration"));
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(Startup));
            services.AddMongoDatabase(Configuration);
            services.AddServices();
            services.AddLocalizationSettings(Configuration);
            services.AddResponseCaching();
            services.AddHealthChecks();
            services.AddMemoryCache();

            services.AddDataProtection()
              .PersistKeysToMongoDb(Configuration)
              .SetApplicationName(Configuration["ApplicationName"]);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(options =>
                  {
                      options.ExpireTimeSpan = TimeSpan.FromHours(1);
                      options.LoginPath = "/Error/NotAuthorized";
                      options.AccessDeniedPath = "/Error/NotAuthorized";
                  });

            services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCustoRewriter();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseRequestLocalization();
            app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                endpoints.MapControllerRoute(
                    name: "culture-route",
                    pattern: "{culture=vi-VN}/{controller=GameRoundResult}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=GameRoundResult}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "demo",
                   pattern: "{controller=Demo}/{action=Index}");
            });
        }
    }
}