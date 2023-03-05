namespace Mardul.Bot.Services.YandexAuthService
{
    public interface IYandexAuthService
    {
        Task<string> GetTokenFromAuthorizationCodeAsync(string authCode);
    }
}
