using Data.Dto.Yandex;
using Newtonsoft.Json;
using System.Net;

namespace Mardul.Bot.Services.YandexAuthService
{
    public class YandexAuthService : IYandexAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly YandexDataDto config;

        public YandexAuthService(IHttpClientFactory httpClientFactory)
        {
            StreamReader data = new StreamReader("config.json");
            string jsonString = data.ReadToEnd();
            config = JsonConvert.DeserializeObject<YandexDataDto>(jsonString);
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetTokenFromAuthorizationCodeAsync(string authCode)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl = config.AccessTokenUrl;

            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("client_id", config.ClientId),
                new KeyValuePair<string, string>("grant_type", config.GrandType),
                new KeyValuePair<string, string>("code", authCode),
                new KeyValuePair<string, string>("redirect_uri", config.CallBackUrl),
                new KeyValuePair<string, string>("client_secret", config.ClientSecret)
             };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = new FormUrlEncodedContent(content),
            };

            HttpResponseMessage response = await client.SendAsync(request);

            string responseContent = await response.Content.ReadAsStringAsync();

            YandexAuthResponseDto? responseObject = JsonConvert.DeserializeObject<YandexAuthResponseDto>(responseContent);

            if (response.IsSuccessStatusCode)
            {
                return (string)responseObject.AccessToken;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                
                throw new Exception("ошибка 400");
            }
            else
            {
                throw new Exception("что-то пошло не так!");
            }
        }
    }
}
