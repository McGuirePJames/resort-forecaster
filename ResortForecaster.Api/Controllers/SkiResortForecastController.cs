using Microsoft.AspNetCore.Mvc;
using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SkiResortForecastController : Controller
    {
        private readonly ISkiResortForecastService _skiResortForecastService;

        public SkiResortForecastController(ISkiResortForecastService skiResortForecastService)
        {
            this._skiResortForecastService = skiResortForecastService;
        }

        [HttpGet]
        public async Task<WeatherForecast> GetSkiResortForecasts()
        {
            var result = await this._skiResortForecastService.GetSkiResortForecast();

            return result;
        }
    }
}
