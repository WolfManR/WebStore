using System.Collections.Generic;

namespace WebStore.Interfaces.Services
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        int Add(T entity);
        void Edit(T entity);
        bool Delete(int id);
        void SaveChanges();
    }
}
