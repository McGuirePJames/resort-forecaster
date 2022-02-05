using Microsoft.Extensions.Logging;
using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class BaseEntityService<TEntity> : IBaseService<TEntity> where TEntity : Base
    {
        private readonly IBaseRepo<TEntity> _baseRepo;
        private ILogger<BaseEntityService<TEntity>> _logger;

        public BaseEntityService(IBaseRepo<TEntity> baseRepo, ILogger<BaseEntityService<TEntity>> logger)
        {
            this._baseRepo = baseRepo;
            this._logger = logger;
        }

        public async Task CreateAsync(TEntity entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                await this._baseRepo.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Error}", ex);
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await this._baseRepo.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Error}", ex);
                throw;
            }
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                throw new Exception("Fuck");

                return await this._baseRepo.GetAllAsync();
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Error}", ex);
                throw;
            }
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            try
            {
                return await this._baseRepo.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Error}", ex);
                throw;
            }
        }

        public async Task UpdateAsync(Guid id, TEntity entity)
        {
            try
            {
                await this._baseRepo.UpdateAsync(id, entity);
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Error}", ex);
                throw;
            }
        }
    }
}
