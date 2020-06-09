using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlUserDataService : IRepo<User>
    {
        private readonly WebStoreDB db;

        public SqlUserDataService(WebStoreDB db) => this.db = db;


        public int Add(User entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));
            if(entity.Id!=0) throw new InvalidOperationException("The primary key is manually set for the employee to be added.");

            db.Accounts.Add(entity);
            return entity.Id;
        }

        public bool Delete(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;

            db.Accounts.Remove(db_item);
            return true;
        }

        public void Edit(User entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            db.Accounts.Update(entity);
        }

        public IEnumerable<User> GetAll() => db.Accounts;

        public User GetById(int id) => db.Accounts.FirstOrDefault(e => e.Id == id);

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
