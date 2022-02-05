namespace ResortForecaster.Services.Interfaces
{
    public interface IBlobStorageService
    {
        Task<T?> DeserializeFile<T>(string fileName);
    }
}
