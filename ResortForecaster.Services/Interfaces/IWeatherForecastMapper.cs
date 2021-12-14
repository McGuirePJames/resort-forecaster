using ResortForecaster.Models;

namespace ResortForecaster.Services.Interfaces
{
    public interface IWeatherForecastMapper
    {
        WeatherForecast FromString(string data);
    }
}
