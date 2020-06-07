using System.Collections.Generic;
using System.Linq;

using WebStore.Data;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Services.InMemory
{
    public class InMemoryBlogDataService : IRepo<BlogPost>
    {
        public IEnumerable<BlogPost> GetAll() => TestData.BlogPosts;
        public BlogPost GetById(int id) => TestData.BlogPosts.FirstOrDefault(x => x.Id == id);
    }
}
