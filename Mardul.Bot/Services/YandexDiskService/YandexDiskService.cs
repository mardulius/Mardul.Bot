namespace Mardul.Bot.Services.YandexDiskService
{
    public class YandexDiskService : IYandexDiskService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public YandexDiskService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<bool> SaveDocumentAsync()
        {
            throw new NotImplementedException();
        }


    }
}
