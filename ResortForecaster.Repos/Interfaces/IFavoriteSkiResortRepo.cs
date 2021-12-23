namespace ResortForecaster.Repos.Interfaces
{
    public interface IFavoriteSkiResortRepo
    {
        Task FavoriteAsync(Guid skiResortId);
    }
}
