using Microsoft.AspNetCore.Mvc;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class FavoriteSkiResortController : Controller
    {
        private readonly IFavoriteSkiResortService _favoriteSkiResortService;

        public FavoriteSkiResortController(IFavoriteSkiResortService favoriteSkiResortService)
        {
            this._favoriteSkiResortService = favoriteSkiResortService;
        }

        [HttpPost]
        public async Task FavoriteSkiResort(Guid skiResortId)
        {
            await this._favoriteSkiResortService.FavoriteSkiResortAsync(Guid.Parse("B1B58459-1139-47EA-9BD3-3BF2A758908F"));
        }
    }
}
