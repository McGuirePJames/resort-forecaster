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
        public async Task FavoriteSkiResort()
        {
            await this._favoriteSkiResortService.FavoriteSkiResort("A");
        }
    }
}
