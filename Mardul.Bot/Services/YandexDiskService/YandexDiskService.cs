using Data.Dto.Yandex;
using Data.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Telegram.Bot.Requests.Abstractions;
using static System.Net.WebRequestMethods;

namespace Mardul.Bot.Services.YandexDiskService
{
    public class YandexDiskService : IYandexDiskService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public YandexDiskService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> SaveDocumentAsync(string yandexToken, string fileName, string filePath)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            string uploadFilePath = $"disk:/Книги/{fileName}";
            string downloadTelegramUrl = $"https://api.telegram.org/file/bot1263428243:AAHDh7kCBRkyDKD11U6rTVIM6Zh7WDPrFu4/{filePath}";

            string uploadUrl = $"https://cloud-api.yandex.net/v1/disk/resources/upload?path={uploadFilePath}&url={downloadTelegramUrl}";


            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uploadUrl);
           
            request.Headers.Add("Authorization", $"OAuth {yandexToken}");

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// получение ссылки для загрузки согласно документации яндекса
        /// </summary>
        /// <param name="client"></param>
        /// <param name="yandexToken"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> GetUrlToUpload(HttpClient client, string yandexToken, string fileName)
        {
            string requestUrl = $"https://cloud-api.yandex.net/v1/disk/resources/upload?path=disk:/Книги/{fileName}";
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

            request.Headers.Add("Authorization", $"OAuth {yandexToken}");
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var fileDownloadData = JsonConvert.DeserializeObject<YandexFIleDownloadDto>(responseContent);
                return fileDownloadData.Href.ToString();
            }
            else
            {
                throw new Exception("что-то пошло не так!");
            }
        }
    }
}
