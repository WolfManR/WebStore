using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities.Base;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services.InSQL.Base
{
    public class BaseRepo<T> : IRepo<T> where T : BaseEntity
    {
        private readonly DbSet<T> table;
        private readonly WebStoreDB db;
        private readonly ILogger<BaseRepo<T>> logger;

        public BaseRepo(WebStoreDB db, ILogger<BaseRepo<T>> logger)
        {
            this.db = db;
            this.logger = logger;
            this.table = db.Set<T>();
        }

        public int Add(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));
            if (entity.Id != 0) throw new InvalidOperationException("The primary key is manually set for the entity to be added.");

            var entry = table.Add(entity);
            return entry.Entity.Id;
        }

        public bool Delete(int id)
        {
            var dbItem = GetById(id);
            if (dbItem is null) return false;

            table.Remove(dbItem);
            return true;
        }

        public void Edit(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            table.Update(entity);
        }

        public IEnumerable<T> GetAll() => table.AsEnumerable();

        public T GetById(int id) => table.FirstOrDefault(e => e.Id == id);

        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Something bad happened while committing changes/n/n{ex.Message}");
            }
        }
    }
}
