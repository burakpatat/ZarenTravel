using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IEntityServiceRepository<T> where T : class, IEntity
    {
        long Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
        T GetByID(int id);
        IEnumerable<T> GetAll();

        IEnumerable<T> GetAllByCache();
        T GetByIDByCache(int id);
    }

}
