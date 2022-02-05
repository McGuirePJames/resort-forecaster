using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;

namespace ResortForecaster.Repos.Repos
{
    public class AvalancheRepo : BaseRepo<Avalanche>, IAvalancheRepo
    {
        public AvalancheRepo(ResortForecasterContext dbContext) : base(dbContext)
        {
        }
    }
}
