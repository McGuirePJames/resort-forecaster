namespace ResortForecaster.Services.Interfaces
{
    public interface IFavoriteSkiResortService
    {
        Task FavoriteSkiResortAsync(Guid skiResortId);
    }
}
