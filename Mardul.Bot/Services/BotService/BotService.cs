using Telegram.Bot;

namespace Mardul.Bot.Services.BotService
{
    public static class BotService
    {
        private static TelegramBotClient botClient { get; set; }


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
