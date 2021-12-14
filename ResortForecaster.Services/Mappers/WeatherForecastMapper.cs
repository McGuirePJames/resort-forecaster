using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Mappers
{
    public class WeatherForecastMapper : IWeatherForecastMapper
    {
        public WeatherForecast FromString(string data)
        {
            var weatherForecast = new WeatherForecast();
            var json = System.Text.Json.JsonDocument.Parse(data).RootElement;

            var currentForecastJson = json.GetProperty("current");
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("clouds").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("sunrise").GetInt64();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("sunset").GetInt64();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("temp").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("feels_like").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("pressure").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("humidity").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("dew_point").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("uvi").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("visibility").GetInt64();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("wind_speed").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("wind_deg").GetInt64();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("wind_gust").GetDecimal();
            weatherForecast.CurrentForecast.Clouds = currentForecastJson.GetProperty("dew_point").GetDecimal();

            return weatherForecast;
        }
    }
}
