using ResortForecaster.Models;

namespace ResortForecaster.Api.GraphQL.Queries
{
    [ExtendObjectType(name: "Query")]
    public class SkiResotQuery
    {
        public List<SkiResort> GetSkiResort() => new List<SkiResort>() { new SkiResort() { SkiResortId = Guid.NewGuid(), Name = "Park City" } };
    }
}
