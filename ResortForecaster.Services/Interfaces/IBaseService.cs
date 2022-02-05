using ResortForecaster.Models;

namespace ResortForecaster.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : Base
    {
        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(Guid id);

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(Guid id, TEntity entity);

        Task DeleteAsync(Guid id);
    }
}
