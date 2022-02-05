using Microsoft.Extensions.Logging;
using ResortForecaster.Models;
using ResortForecaster.Repos.Interfaces;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class AvalancheService : BaseEntityService<Avalanche>, IAvalancheService
    {
        public AvalancheService(IBaseRepo<Avalanche> baseRepo, ILogger<BaseEntityService<Avalanche>> logger) : base(baseRepo, logger)
        {
        }
    }
}
