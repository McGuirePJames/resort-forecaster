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
            try
            {
                var favoriteSkiResort = new FavoriteSkiResort()
                {
                    FavoriteSkiResortId = Guid.NewGuid(),
                    SkiResortId = skiResortId,
                    UserId = Guid.NewGuid().ToString(),
                };

                await this._dbContext.AddAsync<FavoriteSkiResort>(favoriteSkiResort);
                await this._dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
