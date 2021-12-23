using ResortForecaster.Models;

namespace ResortForecaster.Services.Interfaces
{
    public interface ISkiResortService
    {
        Task<List<SkiResort>> GetSkiResortsAsync();

        Task<List<SkiResort>> GetSkiResortsByIdAsync(List<Guid> Ids);
    }
}
