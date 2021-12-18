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
        public void Favorite(string Id)
        {
            try
            {
                var skiResort = this._dbContext.SkiResorts.First();
                var favoriteSkiResort = new FavoriteSkiResort()
                {
                    FavoriteSkiResortId = Guid.NewGuid(),
                    SkiResortId = skiResort.SkiResortId,
                    UserId = Guid.NewGuid().ToString(),
                };


                this._dbContext.Add<FavoriteSkiResort>(favoriteSkiResort);
                this._dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
