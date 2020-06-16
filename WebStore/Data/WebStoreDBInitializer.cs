using Microsoft.EntityFrameworkCore;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities.Base;
using WebStore.Infrastructure.Extensions;

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

            
            TableInitWiaTransaction(db, TestData.Sections);
            
            TableInitWiaTransaction(db, TestData.Brands);

            TableInitWiaTransaction(db, TestData.Products);

            TableInitWiaTransaction(db, TestData.Employees);
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
    }
}
