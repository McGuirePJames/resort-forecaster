using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortForecaster.Models
{
    [Keyless]
    [NotMapped]
    public class CurrentForecast : Base
    {
        public decimal? Clouds { get; set; }
        public decimal? DewPoint { get; set; }
        public decimal? FeelsLike { get; set; }
        public decimal? Humidity { get; set; }
        public decimal? Pressure { get; set; }
        public long? Sunrise { get; set; }
        public long? Sunset { get; set; }
        public decimal? Temp { get; set; }
        public decimal? UVI { get; set; }
        public decimal? Visibility { get; set; }
        public decimal? WindDeg { get; set; }
        public decimal? WindGust { get; set; }
        public decimal? WindSpeed { get; set; }
    }
}
