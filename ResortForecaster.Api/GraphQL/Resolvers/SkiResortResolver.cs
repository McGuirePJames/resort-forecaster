using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Resolvers
{
    public class SkiResortResolver : ObjectType<SkiResort>
    {
        protected override void Configure(IObjectTypeDescriptor<SkiResort> descriptor)
        {
            base.Configure(descriptor);

            descriptor
                .Field(t => t.WeatherForecast)
                .ResolveWith<SkiResortResolvers>(t => t.GetWeatherForecast(default))
                .Name("weatherForecast");
        }

        private class SkiResortResolvers
        {
            private readonly ISkiResortForecastService _skiResortForecastService;

            public SkiResortResolvers(ISkiResortForecastService skiResortForecastService)
            {
                this._skiResortForecastService = skiResortForecastService;
            }

            public async Task<WeatherForecast?> GetWeatherForecast([Parent] SkiResort? skiResort)
            {
                if (skiResort != null)
                {
                    var weatherForecast = await this._skiResortForecastService.GetSkiResortForecastAsync(skiResort.Id);

                    return weatherForecast;
                }

                return null;
            }
        }
    }
}
