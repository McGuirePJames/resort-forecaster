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
            weatherForecast.CurrentForecast.Sunrise = currentForecastJson.GetProperty("sunrise").GetInt64();
            weatherForecast.CurrentForecast.Sunset = currentForecastJson.GetProperty("sunset").GetInt64();
            weatherForecast.CurrentForecast.Temp = currentForecastJson.GetProperty("temp").GetDecimal();
            weatherForecast.CurrentForecast.FeelsLIke = currentForecastJson.GetProperty("feels_like").GetDecimal();
            weatherForecast.CurrentForecast.Pressure = currentForecastJson.GetProperty("pressure").GetDecimal();
            weatherForecast.CurrentForecast.Humidity = currentForecastJson.GetProperty("humidity").GetDecimal();
            weatherForecast.CurrentForecast.DewPoint = currentForecastJson.GetProperty("dew_point").GetDecimal();
            weatherForecast.CurrentForecast.UVI = currentForecastJson.GetProperty("uvi").GetDecimal();
            weatherForecast.CurrentForecast.Visibility = currentForecastJson.GetProperty("visibility").GetInt64();
            weatherForecast.CurrentForecast.WindSpeed = currentForecastJson.GetProperty("wind_speed").GetDecimal();
            weatherForecast.CurrentForecast.WindDeg = currentForecastJson.GetProperty("wind_deg").GetInt64();
            weatherForecast.CurrentForecast.WindGust = currentForecastJson.GetProperty("wind_gust").GetDecimal();

            return weatherForecast;
        }
    }
}
