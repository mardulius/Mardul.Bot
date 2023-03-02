using Telegram.Bot;

namespace Mardul.Bot.Services.BotService
{
    public class BotService
    {
        private static TelegramBotClient botClient { get; set; }
        private readonly IConfiguration _configuration;

        public BotService()
        {

        }
        public static async Task<TelegramBotClient> GetBotAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            botClient = new TelegramBotClient(BotSettings.APIKEY);
            await botClient.SetWebhookAsync(BotSettings.APIURL);

            return botClient;

        }
    }
}
