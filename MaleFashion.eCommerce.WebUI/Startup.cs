using MaleFashion.eCommerce.WebUI.AppCode.BinderProviders;
using MaleFashion.eCommerce.WebUI.AppCode.Hubs;
using MaleFashion.eCommerce.WebUI.AppCode.Middlewares;
using MaleFashion.eCommerce.WebUI.AppCode.Providers;
using MaleFashion.eCommerce.WebUI.Models.DataContext;
using MaleFashion.eCommerce.WebUI.Models.Entity.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
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

                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();

                cfg.Filters.Add(new AuthorizeFilter(policy));
            })
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;


            services.AddDbContext<FashionDbContext>(cfg =>
            {
                cfg.UseSqlServer(conf.GetConnectionString("cString"));
            });

            services.Configure<IdentityOptions>(options =>
            {
                // şifrə tənzimləmələri.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;

                // Kilidləmə tənzimləri.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(13);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // istifadəçi adı tənzimləri.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/signin.html";
                options.AccessDeniedPath = "/accessdenied.html";
                options.SlidingExpiration = true;

                // call cookie
                options.Cookie.Name = ".MaleFashion.eCommerce.Cookie.Analyisers";
                // against cross-site attacks (even if user b has the cookie information of user a, user b cannot do anything, because location)
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<FashionDbContext>();

            services.AddScoped<UserManager<AppUser>>()
                     .AddScoped<RoleManager<AppRole>>()
                     .AddScoped<SignInManager<AppUser>>();

            services.AddScoped<IClaimsTransformation, ClaimsTransformationProvider>();

            services.AddAuthentication();
            //-------------------------------------------
            services.AddAuthorization(options =>
            {
                string[] principals = Program.principals;

                foreach (string principal in principals)
                {
                    options.AddPolicy(principal, cfg =>
                    {
                        cfg.RequireClaim(principal, "1");
                    });
                }
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

            //app.UseMonitoringMiddleware();

            app.UseSession();

            app.DataSeed();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "adminAra",
                    areaName: "admin",
                    pattern: "admin/{controller=Products}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "RegisterRoute",
                    pattern: "register.html",
                    defaults: new
                    {
                        action = "Register",
                        controller = "Account"
                    });

                endpoints.MapControllerRoute(name: "SignInRoute",
                    pattern: "signin.html",
                    defaults: new
                    {
                        action = "SignIn",
                        controller = "Account"
                    });

                endpoints.MapControllerRoute(name: "AccessDeniedRoute",
                    pattern: "accessdenied.html",
                    defaults: new
                    {
                        action = "AccessDeniedRoute",
                        controller = "Account"
                    });

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
