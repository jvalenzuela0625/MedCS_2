using MedCS_2.Application.Common.Interfaces;
using MedCS_2.Presistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace MedCS_2.Presistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MedCSAppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(MedCSAppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task<T?> GetByGuidIdAsync(Guid guid) => await _dbSet.FindAsync(guid);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
    }
}

