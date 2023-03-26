using Data.Dto.User;
using Data.Repositories;

namespace Mardul.Bot.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> GetUserFromChatIdAsync(long ChatId) => await _userRepository.GetUserFromChatIdAsync(ChatId);

        public async Task<string> GetUserYandexTokenAsync(long id)
        {
            return await _userRepository.GetUserYandexTokenAsync(id);
        }

        public async Task SetYandexTokenAsync(UserDto data) => await _userRepository.SetYandexTokenAsync(data);
       
    }
}
