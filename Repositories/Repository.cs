using Microsoft.EntityFrameworkCore;
using SwaggerSchoolAPI.Data;

namespace SwaggerSchoolAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _ctx;
        private readonly DbSet<T> _set;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _set.FindAsync(id);
            if (entity is null) return false;
            _set.Remove(entity);
            await _ctx.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
    }
}
