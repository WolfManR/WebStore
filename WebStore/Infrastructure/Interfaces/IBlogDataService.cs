using System.Collections.Generic;

using WebStore.Domain.Entities;

namespace WebStore.Infrastructure.Interfaces
{
    interface IBlogDataService
    {
        IEnumerable<BlogPost> GetAll();
        BlogPost GetById(int id);
    }
}
