using Telegram.Bot;

namespace Mardul.Bot.Services.BotService
{
    public class BotService
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _botClient { get; set; }

        public BotService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBotAsync()
        {
            if (_botClient != null)
            {
                return _botClient;
            }

            _botClient = new TelegramBotClient(_configuration["Token"]);
            await _botClient.SetWebhookAsync(_configuration["Url"]);

            return _botClient;

        }
    }
}
