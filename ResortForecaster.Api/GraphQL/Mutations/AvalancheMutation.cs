using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Api.GraphQL.Mutations
{
    [ExtendObjectType(name: "Mutation")]
    public class AvalancheMutation
    {
        private readonly IAvalancheService avalancheService;

        public AvalancheMutation(IAvalancheService avalancheService)
        {
            this.avalancheService = avalancheService;
        }

        public async Task<string> AddAvalancheAsync(Avalanche avalanche)
        {
            await this.avalancheService.CreateAsync(avalanche);

            return "";
        }
    }
}
