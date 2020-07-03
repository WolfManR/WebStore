using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebStore.DAL.Context;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;
using WebStore.Services.Extensions;

namespace WebStore.Services.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<WebStoreDBInitializer> logger;

        public WebStoreDBInitializer(WebStoreDB db, UserManager<User> userManager, RoleManager<Role> roleManager, ILogger<WebStoreDBInitializer> logger)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }

        public void Initialize()
        {
            var DB = db.Database;

            if (DB.GetPendingMigrations().Any())
            {
                logger.LogInformation("Preparing to perform database migration");
                DB.Migrate();
                logger.LogInformation("Database migration completed");
            }
            


            TableInitWiaTransaction(db, TestData.Sections, true);

            TableInitWiaTransaction(db, TestData.Brands, true);

            TableInitWiaTransaction(db, TestData.Products, true);

            TableInitWiaTransaction(db, TestData.Employees);

            InitializeIdentityAsync().Wait();
        }

        void TableInitWiaTransaction<T>(DbContext context, IEnumerable<T> data, bool isClearIds = false) where T : BaseEntity
        {
            var table = context.Set<T>();
            if (table.Any()) return;

            var DB = context.Database;

            if (isClearIds)
            {
                var tableName = context.Model.FindEntityType(typeof(T)).GetTableName();
                table.AddRange(data);

                using var transaction = DB.BeginTransaction();

                DB.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] ON");
                context.SaveChanges();
                DB.ExecuteSqlRaw($"SET IDENTITY_INSERT [dbo].[{tableName}] OFF");

                transaction.Commit();
            }
            else
            {
                data.ForEach(t => t.Id = 0);
                table.AddRange(data);

                using var transaction = DB.BeginTransaction();
                db.SaveChanges();
                transaction.Commit();
            }
            
        }

        async Task InitializeIdentityAsync()
        {
            if (!await roleManager.RoleExistsAsync(Role.Administrator))
                await roleManager.CreateAsync(new Role { Name = Role.Administrator });

            if (!await roleManager.RoleExistsAsync(Role.User))
                await roleManager.CreateAsync(new Role { Name = Role.User });

            if (await userManager.FindByNameAsync(User.Administrator) is null)
            {
                var admin = new User { UserName = User.Administrator };

                var create_result = await userManager.CreateAsync(admin, User.DefaultAdminPassword);
                if (create_result.Succeeded) await userManager.AddToRoleAsync(admin, Role.Administrator);
                else
                {
                    var errors = create_result.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Error creating Administrator user: {string.Join(",", errors)}");
                }
            }
        }
    }
}
