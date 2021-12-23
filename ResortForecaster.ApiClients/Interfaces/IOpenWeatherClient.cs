namespace ResortForecaster.ApiClients.Interfaces
{
    public interface IOpenWeatherClient
    {
        Task<string> GetWeatherForecastAsync(decimal latitude, decimal longitude);
    }
}
