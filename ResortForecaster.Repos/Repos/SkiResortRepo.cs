using Microsoft.EntityFrameworkCore;
using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;

namespace ResortForecaster.Repos.Repos
{
    public class SkiResortRepo : ISkiResortRepo
    {
        private readonly ResortForecasterContext _dbContext;

        public SkiResortRepo(ResortForecasterContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<SkiResort>> GetSkiResortsAsync()
        {
            return this._dbContext.SkiResorts.ToList();
        }

        public async Task<List<SkiResort>> GetSkiResortsByIdAsync(List<Guid> skiResortIds)
        {
            return await this._dbContext.SkiResorts.Where((x) => skiResortIds.Contains(x.SkiResortId)).ToListAsync();
        }

        public async Task<SkiResort> GetSkiResortAsync(Guid skiResortId)
        {
            return await this._dbContext.SkiResorts.FindAsync(skiResortId) ?? new SkiResort();
        }
    }
}
