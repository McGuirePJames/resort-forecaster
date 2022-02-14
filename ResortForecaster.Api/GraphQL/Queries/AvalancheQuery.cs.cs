using Microsoft.Extensions.Caching.Memory;
using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Queries
{
    [ExtendObjectType(name: "Query")]
    public class AvalancheQuery
    {
        private readonly IAvalancheService _avalancheService;
        private readonly IMemoryCache _cache;

        public AvalancheQuery(IAvalancheService avalancheService, IMemoryCache cache)
        {
            this._avalancheService = avalancheService;
            this._cache = cache;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<Avalanche>> GetAvalanches()
        {
            var cacheKey = "cachedAvalanches";
            List<Avalanche> cachedAvalanches;


            if (_cache.TryGetValue(cacheKey, out cachedAvalanches))
            {
                return cachedAvalanches;
            }
            else
            {
                cachedAvalanches = await this._avalancheService.GetAllAsync();
                _cache.Set(cacheKey, cachedAvalanches);

                return cachedAvalanches;
            }
        }
    }
}
