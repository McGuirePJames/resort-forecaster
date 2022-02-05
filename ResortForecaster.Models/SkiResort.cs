using System.ComponentModel.DataAnnotations;

namespace ResortForecaster.Models
{
    public class SkiResort : Base
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public WeatherForecast? WeatherForecast { get; set; }
    }
}
