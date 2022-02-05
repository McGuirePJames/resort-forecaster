using Microsoft.AspNetCore.Mvc;
using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SkiResortForecastController : Controller
    {
        private readonly ISkiResortForecastService _skiResortForecastService;
        private readonly IBlobStorageService _blobStorageService;
        private readonly IAvalancheMapper _avalancheMapper;
        private readonly IAvalancheService _avalancheService;

        public SkiResortForecastController(ISkiResortForecastService skiResortForecastService, IBlobStorageService blobStorageService, IAvalancheMapper avalancheMapper, IAvalancheService avalancheService)
        {
            this._skiResortForecastService = skiResortForecastService;
            this._blobStorageService = blobStorageService;
            this._avalancheMapper = avalancheMapper;
            this._avalancheService = avalancheService;
        }

        [HttpGet]
        public async Task<WeatherForecast> GetSkiResortForecasts(Guid skiResortId)
        {
            //var deserializedResult = await this._blobStorageService.DeserializeFile<List<AvalanceRaw>>("avalanches3rd.txt");
            //var avalanches = this._avalancheMapper.FromRaw(deserializedResult);

            //foreach (Avalanche avalanche in avalanches)
            //{
            //    await this._avalancheService.CreateAsync(avalanche);
            //}

            var result = await this._skiResortForecastService.GetSkiResortForecastAsync(skiResortId);
            return result;
        }
    }
}
