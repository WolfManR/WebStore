using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;

using WebStore.Clients.Employees;
using WebStore.Clients.Orders;
using WebStore.Clients.Products;
using WebStore.Clients.Values;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Identity;
using WebStore.Interfaces.Services;
using WebStore.Interfaces.TestApi;
using WebStore.Services.Data;
using WebStore.Services.Profiles;
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
            services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<WebStoreDBInitializer>();

            services.AddAutoMapper(typeof(EmployeeProfile), typeof(ShopProfile));

            services.AddIdentity<Domain.Entities.Identity.User, Role>().AddEntityFrameworkStores<WebStoreDB>().AddDefaultTokenProviders();

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

                .AddScoped<ICartDataService, CookiesCartDataService>()

                .AddSingleton<IRepo<BlogPost>, InMemoryBlogDataService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");
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
