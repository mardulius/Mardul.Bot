using Mardul.Bot.Services.BotService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public class AuthYandexCommand : IBaseCommand
    {
        public CommandNames Name => CommandNames.AuthYandex;
        private readonly TelegramBotClient _botClient;
        public AuthYandexCommand(BotService botService)
        {
            _botClient = botService.GetBotAsync().Result;
        }
        public async Task ExecuteAsync(Update update)
        {
            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"https://oauth.yandex.ru/authorize?response_type=code&client_id=e0f4b3d6522049e48640be058b31afac");
        }
    }
}
