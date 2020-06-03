using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services
{
    public class InMemoryBlogDataService : IBlogDataService
    {
        public IEnumerable<BlogPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public BlogPost GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
