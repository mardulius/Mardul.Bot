namespace Mardul.Bot.Services.YandexDiskService
{
    public interface IYandexDiskService
    {
        Task<bool> SaveDocumentAsync(string yandexToken, string fileName, string filePath);

      
    }
}
