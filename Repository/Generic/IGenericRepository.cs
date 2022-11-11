using System.Linq.Expressions;

namespace Repository.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<bool> Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
