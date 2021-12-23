using ResortForecaster.ApiClients.Interfaces;

namespace ResortForecaster.ApiClients.ApiClients
{
    public class OpenWeatherClient : IOpenWeatherClient
    {
        public async Task<string> GetWeatherForecastAsync(decimal latitude, decimal longitude)
        {
            using var client = new HttpClient();

            var request = await client.GetAsync($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&appid=3da1236b78782de223fcc84bb1b509b3");
            var result = await request.Content.ReadAsStringAsync();

            return result;
        }
    }
}
