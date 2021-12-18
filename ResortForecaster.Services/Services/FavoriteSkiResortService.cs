using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class FavoriteSkiResortService : IFavoriteSkiResortService
    {
        private readonly IFavoriteSkiResortRepo _favoriteSkiResortRepo;

        public FavoriteSkiResortService(IFavoriteSkiResortRepo favoriteSkiResortRepo)
        {
            this._favoriteSkiResortRepo = favoriteSkiResortRepo;
        }

        public async Task FavoriteSkiResort(string skiResortId)
        {
            this._favoriteSkiResortRepo.Favorite(skiResortId);
        }
    }
}
