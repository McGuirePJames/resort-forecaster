using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Queries
{
    [ExtendObjectType(name: "Query")]
    public class AvalancheQuery
    {
        private readonly IAvalancheService _avalancheService;

        public AvalancheQuery(IAvalancheService avalancheService)
        {
            this._avalancheService = avalancheService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Avalanche>> GetAvalanches()
        {
            return await this._avalancheService.GetAllAsync();
        }
    }
}
