using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;

namespace ResortForecaster.Repos.Repos
{
    public class FavoriteSkiResortRepo : IFavoriteSkiResortRepo
    {
        private readonly ResortForecasterContext _dbContext;

        public FavoriteSkiResortRepo(ResortForecasterContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task FavoriteAsync(Guid skiResortId)
        {
            var favoriteSkiResort = new FavoriteSkiResort()
            {
                Id = Guid.NewGuid(),
                SkiResortId = skiResortId,
                UserId = Guid.NewGuid().ToString(),
            };

            await this._dbContext.AddAsync<FavoriteSkiResort>(favoriteSkiResort);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
