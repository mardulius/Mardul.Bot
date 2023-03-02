using Data;
using Data.Models;
using Mardul.Bot.Services.BotService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public class RegistrationCommand : IBaseCommand
    {
        private readonly TelegramBotClient _botClient;
        private readonly BotContext _botContext;
        public CommandNames Name => CommandNames.Registration;
        public RegistrationCommand(BotService botService, BotContext botContext)
        {
            _botClient = botService.GetBotAsync().Result;
            _botContext = botContext;
        }
        public async Task ExecuteAsync(Update update)
        {
            await _botContext.Users.AddAsync(new Data.Models.User
            {
                TelegramUserId = update.Message.From.Id,
                ChatId = update.Message.Chat.Id,
                Name = update.Message.From.Username
            });
            await _botContext.SaveChangesAsync();
            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"{update.Message?.From?.Username} - успешно зарегистрирован!");
        }
    }
}
