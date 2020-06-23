using System.Collections.Generic;
using System.Linq;

using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InMemory
{
    public class InMemoryBlogDataService : IRepo<BlogPost>
    {
        public int Add(BlogPost entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(BlogPost entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BlogPost> GetAll() => TestData.BlogPosts;
        public BlogPost GetById(int id) => TestData.BlogPosts.FirstOrDefault(x => x.Id == id);

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
