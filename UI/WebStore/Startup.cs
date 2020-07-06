using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;

using WebStore.Clients.Employees;
using WebStore.Clients.Identity;
using WebStore.Clients.Orders;
using WebStore.Clients.Products;
using WebStore.Clients.Values;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Middleware;
using WebStore.Interfaces.Services;
using WebStore.Interfaces.TestApi;
using WebStore.Logger.Log4Net;
using WebStore.Services.Profiles;
using WebStore.Services.Services;
using WebStore.Services.Services.InCookies;
using WebStore.Services.Services.InMemory;

namespace WebStore
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EmployeeProfile), typeof(ShopProfile));

            services.AddIdentity<Domain.Entities.Identity.User, Role>().AddDefaultTokenProviders();

            #region WebApi Identity clients store

            services
                .AddTransient<IUserStore<Domain.Entities.Identity.User>, UsersClient>()
                .AddTransient<IUserPasswordStore<Domain.Entities.Identity.User>, UsersClient>()
                .AddTransient<IUserEmailStore<Domain.Entities.Identity.User>, UsersClient>()
                .AddTransient<IUserPhoneNumberStore<Domain.Entities.Identity.User>, UsersClient>()
                .AddTransient<IUserTwoFactorStore<Domain.Entities.Identity.User>, UsersClient>()
                .AddTransient<IUserClaimStore<Domain.Entities.Identity.User>, UsersClient>()
                .AddTransient<IUserLoginStore<Domain.Entities.Identity.User>, UsersClient>();
            services
                .AddTransient<IRoleStore<Role>, RolesClient>();

            #endregion

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 3;

                opt.User.RequireUniqueEmail = false;
#endif
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 4;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "WebStore";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);

                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Errors/AccessDenied";

                opt.SlidingExpiration = true;
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services
                .AddScoped<IRepo<Employee>, EmployeesClient>()
                .AddScoped<IProductDataService, ProductsClient>()
                .AddScoped<IOrderDataService, OrdersClient>()

                .AddTransient<IValueService, ValuesClient>()

                .AddScoped<ICartRepo, CookiesCartRepo>()
                .AddScoped<ICartDataService, CartDataService>()

                .AddSingleton<IRepo<BlogPost>, InMemoryBlogDataService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            log.AddLog4Net();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");
            app.UseMiddleware<ErrorHandlingMiddleware>();
            // needed for work MVC
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                        name: "areaAdmin",
                        areaName: "Admin",
                        pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Home}/{id?}");
            });
        }
    }
}
