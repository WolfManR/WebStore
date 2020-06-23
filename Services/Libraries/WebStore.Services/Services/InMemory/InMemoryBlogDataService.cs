using System.Collections.Generic;
using System.Linq;

using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;

namespace WebStore.Services.Services.InMemory
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
