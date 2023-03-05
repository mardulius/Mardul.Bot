using Newtonsoft.Json;
using System.Net;

namespace Mardul.Bot.Services.YandexAuthService
{
    public class YandexAuthService : IYandexAuthService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly YandexData _data;

        public YandexAuthService(IHttpClientFactory httpClientFactory)
        {
            StreamReader r = new StreamReader("config.json");
            string jsonString = r.ReadToEnd();
            _data = JsonConvert.DeserializeObject<YandexData>(jsonString);
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetTokenFromAuthorizationCodeAsync(string authCode)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string requestUrl = _data.AccessTokenUrl;

            List<KeyValuePair<string, string>> content = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("client_id", _data.ClientId),
                new KeyValuePair<string, string>("grant_type", _data.GrandType),
                new KeyValuePair<string, string>("code", authCode),
                new KeyValuePair<string, string>("redirect_uri", _data.CallBackUrl),
                new KeyValuePair<string, string>("client_secret", _data.ClientSecret)
             };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUrl)
            {
                Content = new FormUrlEncodedContent(content),
            };

            HttpResponseMessage response = await client.SendAsync(request);

            string responseContent = await response.Content.ReadAsStringAsync();

            dynamic responseObject = JsonConvert.DeserializeObject(responseContent);

            if (response.IsSuccessStatusCode)
            {
                return (string)responseObject.access_token;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                
                throw new Exception((string)responseObject.error_description);
            }
            else
            {
                // ¯\_(ツ)_/¯
                throw new Exception("Something bad happened");
            }
        }
    }
}
