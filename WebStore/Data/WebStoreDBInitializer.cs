using Microsoft.EntityFrameworkCore;

using System.Linq;

using WebStore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB db;

        public WebStoreDBInitializer(WebStoreDB db) => this.db = db;

        public void Initialize()
        {
            var DB = db.Database;
            DB.Migrate();

            if (db.Products.Any()) return;

            using(DB.BeginTransaction())
            {
                db.Sections.AddRange(TestData.Sections);

                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSection] ON");
                db.SaveChanges();
                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSection] OFF");

                DB.CommitTransaction();
            }

            using(var transaction = DB.BeginTransaction())
            {
                db.Brands.AddRange(TestData.Brands);

                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrand] ON");
                db.SaveChanges();
                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrand] OFF");

                transaction.Commit();
            }

            using (var transaction = DB.BeginTransaction())
            {
                db.Products.AddRange(TestData.Products);

                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                db.SaveChanges();
                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                transaction.Commit();
            }

            using (var transaction = DB.BeginTransaction())
            {
                db.Accounts.AddRange(TestData.Accounts);

                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Accounts] ON");
                db.SaveChanges();
                DB.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Accounts] OFF");

                transaction.Commit();
            }
        }
    }
}
