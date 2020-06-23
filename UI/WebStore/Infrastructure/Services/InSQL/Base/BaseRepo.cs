using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities.Base;
using WebStore.Interfaces.Services;

namespace WebStore.Infrastructure.Services.InSQL.Base
{
    public class BaseRepo<T> : IRepo<T> where T : BaseEntity
    {
        private readonly DbSet<T> table;
        private readonly WebStoreDB db;

        public BaseRepo(WebStoreDB db)
        {
            this.db = db;
            this.table = db.Set<T>();
        }

        public int Add(T entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));
            if (entity.Id != 0) throw new InvalidOperationException("The primary key is manually set for the entity to be added.");

            table.Add(entity);
            return entity.Id;
        }

        public bool Delete(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;

            table.Remove(db_item);
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
