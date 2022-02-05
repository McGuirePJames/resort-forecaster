using ResortForecaster.Models;

namespace ResortForecaster.Services.Interfaces
{
    public interface IAvalancheMapper
    {
        List<Avalanche> FromRaw(List<AvalanceRaw>? avalanceRaws);
    }
}
