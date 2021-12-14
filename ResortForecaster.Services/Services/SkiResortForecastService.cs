using ResortForecaster.ApiClients.Interfaces;
using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class SkiResortForecastService : ISkiResortForecastService
    {
        private readonly IOpenWeatherClient _openWeatherClient;
        private readonly IWeatherForecastMapper _weatherForecastMapper;

        public SkiResortForecastService(IOpenWeatherClient openWeatherClient, IWeatherForecastMapper weatherForecastMapper)
        {
            this._openWeatherClient = openWeatherClient;
            this._weatherForecastMapper = weatherForecastMapper;
        }

        public async Task<WeatherForecast> GetSkiResortForecast()
        {
            var result = await this._openWeatherClient.GetWeatherForecastAsync();
            var mapResult = _weatherForecastMapper.FromString(result);

            return mapResult;
        }
    }
}
