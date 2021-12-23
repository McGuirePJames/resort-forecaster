using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Queries
{
    [ExtendObjectType(name: "Query")]
    public class SkiResortForecastQuery
    {
        private readonly ISkiResortForecastService _skiResortForecastService;

        public SkiResortForecastQuery(ISkiResortForecastService skiResortForecastService)
        {
            this._skiResortForecastService = skiResortForecastService;
        }

        public async Task<WeatherForecast> GetForecast(string skiResortId)
        {
            var result = await this._skiResortForecastService.GetSkiResortForecastAsync(Guid.Parse(skiResortId));

            return result;
        }
    }
}
