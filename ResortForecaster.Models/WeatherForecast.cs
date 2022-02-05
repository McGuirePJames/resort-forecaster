using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortForecaster.Models
{
    [Keyless]
    [NotMapped]
    public class WeatherForecast
    {
        public WeatherForecast()
        {
            this.CurrentForecast = new CurrentForecast();
        }

        public CurrentForecast CurrentForecast { get; set; }
    }
}
