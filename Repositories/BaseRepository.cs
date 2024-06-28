using Microsoft.EntityFrameworkCore;
using SummerWebinarApp.Data;

namespace SummerWebinarApp.Repositories
{

    // Base repository class providing basic CRUD operations for entities of type T
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected readonly SummerWebinarDbContext _context;
        private readonly DbSet<T> _dbSet;

        // Constructor to initialize context and DbSet
        public BaseRepository(SummerWebinarDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Adds a new entity of type T asynchronously
        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        // Adds a range of entities of type T asynchronously
        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        // Updates an existing entity of type T asynchronously
        public virtual void UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            //_dbSet.Update(entity);
        }

        // Deletes an entity of type T by its ID asynchronously, returning true if successful
        public virtual async Task<bool> DeleteAsync(int id)
        {
            T? existing = await _dbSet.FindAsync(id);
            if (existing is not null)
            {
                _dbSet.Remove(existing);
                return true;
            }
            return false;
        }

        // Retrieves an entity of type T by its ID asynchronously

        public virtual async Task<T?> GetAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        // Retrieves all entities of type T asynchronously
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return entities;
        }

        // Retrieves the count of entities of type T asynchronously
        public virtual async Task<int> GetCountAsync()
        {
            var count = await _dbSet.CountAsync();
            return count;
        }
    }
}
