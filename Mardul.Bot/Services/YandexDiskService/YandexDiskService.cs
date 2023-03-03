namespace Mardul.Bot.Services.YandexDiskService
{
    public class YandexDiskService : IYandexDiskService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public YandexDiskService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> AuthorizeAsync()
        {
            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://oauth.yandex.ru/authorize?response_type=code&client_id=e0f4b3d6522049e48640be058b31afac");
            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
