using Data.Dto.User;

namespace Mardul.Bot.Services.UserService
{
    public interface IUserService
    {
        Task<UserDto> GetUserFromChatIdAsync(long userId);
        Task SetYandexTokenAsync(UserDto data);
    }
}
