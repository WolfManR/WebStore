using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Profiles;
using WebStore.Infrastructure.Services.InMemory;
using WebStore.Infrastructure.Services.InSQL;

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

            services.AddAutoMapper(typeof(AccountProfile));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddScoped<IRepo<Account>, SqlAccountDataService>();
            services.AddScoped<IProductDataService, SqlProductDataService>();
            services.AddSingleton<IRepo<BlogPost>, InMemoryBlogDataService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDBInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            // needed for work MVC
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Home}/{id?}");
            });
        }
    }
}
