using System;
using System.Collections.Generic;
using System.Linq;

using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InSQL
{
    public class SqlAccountDataService : IRepo<Account>
    {
        private readonly WebStoreDB db;

        public SqlAccountDataService(WebStoreDB db) => this.db = db;


        public int Add(Account entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            db.Accounts.Add(entity);

            SaveChanges();

            return entity.Id;
        }

        public bool Delete(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;

            db.Accounts.Remove(db_item);

            SaveChanges();

            return true;
        }

        public void Edit(Account entity)
        {
            _ = entity ?? throw new ArgumentNullException(nameof(entity));

            var db_item = GetById(entity.Id);
            if (db_item is null) return;

            db.Accounts.Update(entity);
            SaveChanges();
        }

        public IEnumerable<Account> GetAll() => db.Accounts;

        public Account GetById(int id) => db.Accounts.FirstOrDefault(e => e.Id == id);

        public void SaveChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
