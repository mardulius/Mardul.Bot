using Mardul.Bot.Services.BotService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public class StartCommand : IBaseCommand
    {
      
        private readonly TelegramBotClient _botClient;
        public StartCommand(BotService botService)
        {
            _botClient = botService.GetBotAsync().Result;
        }

        public CommandNames Name => CommandNames.Start;

        public async Task ExecuteAsync(Update update)
        {
            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"Привет, {update.Message?.From?.Username}!");
        }
    }
}
