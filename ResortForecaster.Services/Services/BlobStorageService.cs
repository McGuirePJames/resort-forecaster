using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResortForecaster.Models;
using ResortForecaster.Services.Interfaces;

namespace ResortForecaster.Services.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly AzureAccountStorageOptions _azureAccountStorageOptions;
        private readonly ILogger<BlobStorageService> _logger;

        public BlobStorageService(IOptions<AzureAccountStorageOptions> azureAccountStorageOptions, ILogger<BlobStorageService> logger)
        {
            this._azureAccountStorageOptions = azureAccountStorageOptions.Value;
            this._logger = logger;
        }

        public async Task<T?> DeserializeFile<T>(string fileName)
        {
            try
            {
                BlobServiceClient blobServiceClient = new BlobServiceClient(this._azureAccountStorageOptions.ConnectionString);
                var containerClient = blobServiceClient.GetBlobContainerClient(this._azureAccountStorageOptions.ContainerName);
                var blobClient = containerClient.GetBlobClient(fileName);

                using (Stream stream = await blobClient.OpenReadAsync())
                using (StreamReader sr = new StreamReader(stream))
                using (JsonTextReader jtr = new JsonTextReader(sr))
                {
                    var ser = new JsonSerializer();
                    var result = ser.Deserialize<T>(jtr);

                    return result;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError("{@Error}", ex);
                throw;
            }
        }
    }
}
