using Data;
using Data.Dto;
using Data.Dto.User;
using Data.Models;
using Data.Repositories;
using Mardul.Bot.Services.BotService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public class RegistrationCommand : IBaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly IUserRepository _userRepository;
        public CommandNames Name => CommandNames.Registration;
        public RegistrationCommand(BotService botService, IUserRepository userRepository)
        {
            _botClient = botService.GetBotAsync().Result;
            _userRepository = userRepository;
        }
        public async Task ExecuteAsync(Update update)
        {
            var result = await _userRepository.AddUserAsync(new UserDto
            {
                Id = update.Message.Chat.Id,
                Name = update.Message.From.Username
            });
            if (result)
            {
                await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"{update.Message?.From?.Username} - успешно зарегистрирован!");
            }
            else
            {
                await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"{update.Message?.From?.Username} - уже зарегистрирован!");
            }
        }
    }
}
