using Telegram.Bot;

namespace Mardul.Bot.Services.BotService
{
    public class BotService
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient botClient { get; set; }

        public BotService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBotAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            botClient = new TelegramBotClient(_configuration["Token"]);
            await botClient.SetWebhookAsync(_configuration["Url"]);

            return botClient;

        }
    }
}
