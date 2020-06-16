using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebStore.DAL.Context;
using WebStore.Domain.Entities.Base;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Extensions;

namespace WebStore.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public WebStoreDBInitializer(WebStoreDB db, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            var DB = db.Database;
            DB.Migrate();


            TableInitWiaTransaction(db, TestData.Sections);

            TableInitWiaTransaction(db, TestData.Brands);

            TableInitWiaTransaction(db, TestData.Products);

            TableInitWiaTransaction(db, TestData.Employees);

            InitializeIdentityAsync().Wait();
        }

        void TableInitWiaTransaction<T>(DbContext context, IEnumerable<T> data) where T : BaseEntity
        {
            var table = context.Set<T>();
            if (table.Any()) return;

            var DB = context.Database;
            data.ForEach(t => t.Id = 0);

            using var transaction = DB.BeginTransaction();
            table.AddRange(data);

            db.SaveChanges();

            transaction.Commit();
        }

        async Task InitializeIdentityAsync()
        {
            if (!await roleManager.RoleExistsAsync(Role.Administrator))
                await roleManager.CreateAsync(new Role { Name = Role.Administrator });

            if (!await roleManager.RoleExistsAsync(Role.User))
                await roleManager.CreateAsync(new Role { Name = Role.User });

            if (await roleManager.FindByNameAsync(User.Administrator) is null)
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
