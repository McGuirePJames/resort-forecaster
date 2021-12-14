namespace ResortForecaster.Models
{
    public class WeatherForecast
    {
        public WeatherForecast()
        {
            this.CurrentForecast = new CurrentForecast();
        }

        public CurrentForecast CurrentForecast { get; set; }
    }
}
