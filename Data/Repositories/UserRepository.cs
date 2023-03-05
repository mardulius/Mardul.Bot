using Data.Dto.User;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BotContext _botContext;

        public UserRepository(BotContext botContext)
        {
            _botContext = botContext;
        }

        public async Task<bool> AddUserAsync(UserDto data)
        {
            var user = _botContext.Users.FirstOrDefault(x => x.Id == data.Id);
            if (user == null)
            {
                await _botContext.Users.AddAsync(new Data.Models.User
                {
                    Id = data.Id,
                    Name = data.Name,
                    DateCreated = DateTime.Now,
                });
                await _botContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<UserDto> GetUserFromChatIdAsync(long ChatId)
        {
            var user = await _botContext.Users.Where(x => x.Id == ChatId).FirstOrDefaultAsync();

            var result = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                YandexTokenId = user.TokenId
            };

            return result;

        }

        public async Task SetYandexTokenAsync(UserDto data)
        {
            _botContext.YandexTokens.AddAsync(new YandexToken
            {
                Token = data.YandexToken,
                UserId = data.Id
            });
            await _botContext.SaveChangesAsync();
            var token = _botContext.YandexTokens.FirstOrDefault(x => x.UserId == data.Id);

            var user = _botContext.Users.First(x => x.Id == data.Id);
            user.TokenId = token.Id;
            _botContext.Users.Update(user);

            await _botContext.SaveChangesAsync();
        }
    }
}
