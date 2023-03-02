using Data.Dto;
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
            var user = _botContext.Users.FirstOrDefault(x=> x.TelegramUserId == data.TelegramUserId);
            if (user == null)
            {
                await _botContext.Users.AddAsync(new Data.Models.User
                {
                    TelegramUserId = data.TelegramUserId,
                    ChatId = data.ChatId,
                    Name = data.Name,
                    DateCreated = DateTime.Now,
                });
                await _botContext.SaveChangesAsync();
                return true;
            }
           return false;
        }
    }
}
