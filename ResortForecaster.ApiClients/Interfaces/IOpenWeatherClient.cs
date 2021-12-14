namespace ResortForecaster.ApiClients.Interfaces
{
    public interface IOpenWeatherClient
    {
        Task<string> GetWeatherForecastAsync();
    }
}
