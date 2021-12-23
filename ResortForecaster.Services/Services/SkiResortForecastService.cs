using ResortForecaster.ApiClients.Interfaces;
using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class SkiResortForecastService : ISkiResortForecastService
    {
        private readonly IOpenWeatherClient _openWeatherClient;
        private readonly IWeatherForecastMapper _weatherForecastMapper;
        private readonly ISkiResortRepo _skiResortRepo;

        public SkiResortForecastService(IOpenWeatherClient openWeatherClient, IWeatherForecastMapper weatherForecastMapper, ISkiResortRepo skiResortRepo)
        {
            this._openWeatherClient = openWeatherClient;
            this._weatherForecastMapper = weatherForecastMapper;
            this._skiResortRepo = skiResortRepo;
        }

        public async Task<WeatherForecast> GetSkiResortForecastAsync(Guid skiResortId)
        {
            try
            {
                var skiResort = await this._skiResortRepo.GetSkiResortAsync(skiResortId);

                if (skiResort != null)
                {
                    var result = await this._openWeatherClient.GetWeatherForecastAsync(skiResort.Latitude, skiResort.Longitude);
                    var mapResult = _weatherForecastMapper.FromString(result);

                    return mapResult;
                }
            }
            catch (Exception ex)
            {

            }

            return new WeatherForecast();
        }
    }
}
