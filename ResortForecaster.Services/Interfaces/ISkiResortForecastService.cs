using ResortForecaster.Models;

namespace ResortForecaster.Services.Interfaces
{
    public interface ISkiResortForecastService
    {
        public Task<WeatherForecast> GetSkiResortForecastAsync(Guid skiResortId);
    }
}
