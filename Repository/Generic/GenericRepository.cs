using System.Linq.Expressions;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly IDbContextFactory<Context> ContextFactory;
        //protected readonly Context _context;
        public GenericRepository(IDbContextFactory<Context> contextFactory)
        {
            ContextFactory = contextFactory;
        }
        public async Task<T> Add(T entity)
        {
            using (Context context = await ContextFactory.CreateDbContextAsync())
            {
                await context.Set<T>().AddAsync(entity);

                await context.SaveChangesAsync();

                return entity;
            }
        }
        public void AddRange(IEnumerable<T> entities)
        {
            using (Context context = ContextFactory.CreateDbContext())
            {
                context.Set<T>().AddRange(entities);

                context.SaveChanges();
            }
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            using (Context context = ContextFactory.CreateDbContext())
            {
                return context.Set<T>().Where(expression);
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            using (Context context = await ContextFactory.CreateDbContextAsync())
            {
                return await context.Set<T>().ToListAsync();
            }
        }
        public async Task<T?> GetById(Guid id)
        {
            using (Context context = await ContextFactory.CreateDbContextAsync())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
        public async Task<bool> Remove(T entity)
        {
            using (Context context = await ContextFactory.CreateDbContextAsync())
            {
                context.Set<T>().Remove(entity);

                return await context.SaveChangesAsync() > 0;
            }
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            using (Context context = ContextFactory.CreateDbContext())
            {
                context.Set<T>().RemoveRange(entities);

                context.SaveChanges();
            }
        }
    }
}
