using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;
using Utils = ResortForecaster.Utilities.Utilities;

namespace ResortForecaster.Services.Mappers
{
    public class WeatherForecastMapper : IWeatherForecastMapper
    {
        public WeatherForecast FromString(string data)
        {
            var weatherForecast = new WeatherForecast();
            var json = System.Text.Json.JsonDocument.Parse(data).RootElement;

            var currentForecastJson = json.GetProperty("current");
            weatherForecast.CurrentForecast.Clouds = Utils.TryParseOut <decimal>(Utils.TryGetProperty("clouds", currentForecastJson));
            weatherForecast.CurrentForecast.Sunrise = Utils.TryParseOut<Int64>(Utils.TryGetProperty("sunrise", currentForecastJson));
            weatherForecast.CurrentForecast.Sunset = Utils.TryParseOut<Int64>(Utils.TryGetProperty("sunset", currentForecastJson));
            weatherForecast.CurrentForecast.Temp = Utils.TryParseOut<decimal>(Utils.TryGetProperty("temp", currentForecastJson));
            weatherForecast.CurrentForecast.FeelsLike = Utils.TryParseOut<decimal>(Utils.TryGetProperty("feels_like", currentForecastJson));
            weatherForecast.CurrentForecast.Pressure = Utils.TryParseOut<decimal>(Utils.TryGetProperty("pressure", currentForecastJson));
            weatherForecast.CurrentForecast.Humidity = Utils.TryParseOut<decimal>(Utils.TryGetProperty("humidity", currentForecastJson));
            weatherForecast.CurrentForecast.DewPoint = Utils.TryParseOut<decimal>(Utils.TryGetProperty("dew_point", currentForecastJson));
            weatherForecast.CurrentForecast.UVI = Utils.TryParseOut<decimal>(Utils.TryGetProperty("uvi", currentForecastJson));
            weatherForecast.CurrentForecast.Visibility = Utils.TryParseOut<Int64>(Utils.TryGetProperty("visibility", currentForecastJson));
            weatherForecast.CurrentForecast.WindSpeed = Utils.TryParseOut<Decimal>(Utils.TryGetProperty("wind_speed", currentForecastJson));
            weatherForecast.CurrentForecast.WindDeg = Utils.TryParseOut<Decimal>(Utils.TryGetProperty("wind_deg", currentForecastJson));
            weatherForecast.CurrentForecast.WindGust = Utils.TryParseOut<Decimal>(Utils.TryGetProperty("wind_gust", currentForecastJson));

            return weatherForecast;
        }
    }
}
