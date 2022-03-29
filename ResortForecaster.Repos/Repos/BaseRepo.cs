using Microsoft.EntityFrameworkCore;
using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;

namespace ResortForecaster.Repos.Repos
{
    public class BaseRepo<TEntity> : IBaseRepo<TEntity> where TEntity : Base
    {
        private readonly ResortForecasterContext _dbContext;

        public BaseRepo(ResortForecasterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var result = await _dbContext.Set<TEntity>().AsQueryable()
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task UpdateAsync(Guid id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
