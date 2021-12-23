using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class SkiResortService : ISkiResortService
    {
        private readonly ISkiResortRepo _skiResortRepo;
        
        public SkiResortService(ISkiResortRepo skiResortRepo)
        {
            this._skiResortRepo = skiResortRepo;
        }

        public async Task<List<SkiResort>> GetSkiResortsAsync()
        {
            return await this._skiResortRepo.GetSkiResortsAsync();
        }

        public async Task<List<SkiResort>> GetSkiResortsByIdAsync(List<Guid> Ids)
        {
            return await this._skiResortRepo.GetSkiResortsByIdAsync(Ids);
        }
    }
}
