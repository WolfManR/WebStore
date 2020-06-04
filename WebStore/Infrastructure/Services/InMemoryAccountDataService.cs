using System.Collections.Generic;
using System.Linq;

using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryAccountDataService : IRepo<Account>
    {
        public IEnumerable<Account> GetAll() => TestData.Accounts;
        public Account GetById(int id) => TestData.Accounts.FirstOrDefault(x=>x.Id==id);
    }
}
