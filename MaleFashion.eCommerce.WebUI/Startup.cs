using MaleFashion.eCommerce.WebUI.AppCode.BinderProviders;
using MaleFashion.eCommerce.WebUI.AppCode.Hubs;
using MaleFashion.eCommerce.WebUI.AppCode.Middlewares;
using MaleFashion.eCommerce.WebUI.Models.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaleFashion.eCommerce.WebUI
{
    public class Startup
    {
        private readonly IConfiguration conf;

        public Startup(IConfiguration conf)
        {
            this.conf = conf;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                //options.LowercaseQueryStrings = true;
            });

            services.AddSignalR();

            services.AddSession(requirements =>
            {
                // Enner Valencia - 13
                requirements.IdleTimeout = TimeSpan.FromMilliseconds(13);
            });

            services.AddControllersWithViews(cfg =>
            {
                cfg.ModelBinderProviders.Insert(0, new BooleanBinderProvider());
            })
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;


            services.AddDbContext<FashionDbContext>(cfg =>
        {
            cfg.UseSqlServer(conf.GetConnectionString("cString"));
        });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // My IP Blocker Middleware
            //app.UseIPBlockerMiddleware();

            app.UseMonitoringMiddleware();

            app.UseSession();

            app.DataSeed();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "adminAra",
                    areaName: "admin",
                    pattern: "admin/{controller=Products}/{action=Index}/{id?}");

                endpoints.MapHub<ConversationHub>("/chat");

                // Defaults, Liar Routes
                endpoints.MapControllerRoute(name: "BlogRoute",
                    pattern: "blog.html",
                    defaults: new
                    {
                        action = "Index",
                        controller = "Blog"
                    });

                // Route Constraints
                endpoints.MapControllerRoute(name: "BlogRoute",
                   pattern: "{controller=Home}/{action=Index}/{id?}",
                   //pattern: "{controller=Home}/{action=Index}/{id:int:min(1)}",
                   constraints: new
                   {
                       id = new IRouteConstraint[]
                       {
                          new MinLengthRouteConstraint(1)
                       }
                   });

                endpoints.MapControllerRoute(name: "default",
                                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
