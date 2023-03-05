using Data.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUserAsync(UserDto data);
        Task<UserDto> GetUserFromChatIdAsync(long userId);
        Task SetYandexTokenAsync(UserDto data);
    }
}
