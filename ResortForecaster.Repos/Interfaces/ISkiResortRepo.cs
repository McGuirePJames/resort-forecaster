using ResortForecaster.Models;

namespace ResortForecaster.Repos.Interfaces
{
    public interface ISkiResortRepo
    {
        Task<List<SkiResort>> GetSkiResortsByIdAsync(List<Guid> skiResortIds);
        Task<SkiResort> GetSkiResortAsync(Guid skiResortId);
        Task<List<SkiResort>> GetSkiResortsAsync();
    }
}
