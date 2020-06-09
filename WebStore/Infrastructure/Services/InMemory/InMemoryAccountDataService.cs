﻿using System.Collections.Generic;
using System.Linq;

using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InMemory
{
    public class InMemoryAccountDataService : IRepo<User>
    {
        public IEnumerable<User> GetAll() => TestData.Accounts;
        public User GetById(int id) => TestData.Accounts.FirstOrDefault(x => x.Id == id);

        public int Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
