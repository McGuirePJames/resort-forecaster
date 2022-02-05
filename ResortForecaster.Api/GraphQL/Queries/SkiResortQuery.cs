using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Queries
{
    [ExtendObjectType(name: "Query")]
    public class SkiResortQuery
    {

        private readonly ISkiResortService _skiResortService;

        public SkiResortQuery(ISkiResortService skiResortService)
        {
            this._skiResortService = skiResortService;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<List<SkiResort>> GetSkiResorts()
        {
            return await this._skiResortService.GetSkiResortsAsync();
        }

        public async Task<List<SkiResort>> GetSkiResortsById(List<Guid> Ids)
        {
            return await this._skiResortService.GetSkiResortsAsync();
        }
    }
}
