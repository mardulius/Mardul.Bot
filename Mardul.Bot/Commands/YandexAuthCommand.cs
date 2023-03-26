using Mardul.Bot.Services.BotService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public class YandexAuthCommand : IBaseCommand
    {
        public CommandNames Name => CommandNames.YandexAuth;
        private readonly TelegramBotClient _botClient;
        private readonly IConfiguration _configuration;
        public YandexAuthCommand(BotService botService, IConfiguration configuration)
        {
            _botClient = botService.GetBotAsync().Result;
            _configuration = configuration;
        }
        public async Task ExecuteAsync(Update update)
        {
            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"{_configuration["RequestCodeUrl"]}{update.Message.Chat.Id}");
        }

    }
}
