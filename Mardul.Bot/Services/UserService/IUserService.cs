using Data.Dto.User;

namespace Mardul.Bot.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUserFromChatIdAsync(long userId);
        Task <string> GetUserYandexTokenAsync(long id);
        Task SetYandexTokenAsync(UserDto data);
    }
}
