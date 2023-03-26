using Mardul.Bot.Services.BotService;
using Mardul.Bot.Services.UserService;
using Mardul.Bot.Services.YandexDiskService;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public class YandexDiskCommand : IBaseCommand
    {
        public CommandNames Name => CommandNames.YandexDisk;
        private readonly TelegramBotClient _botClient;
        private readonly IYandexDiskService _yandexDiskService;
        private readonly IUserService _userService;
        public YandexDiskCommand(BotService botService, IYandexDiskService yandexDiskService, IUserService userService)
        {
            _botClient = botService.GetBotAsync().Result;
            _yandexDiskService = yandexDiskService;
            _userService = userService;
        }
        public async Task ExecuteAsync(Update update)
        {
            var yandexToken = await _userService.GetUserYandexTokenAsync(update.Message.Chat.Id);
            if (yandexToken != null)
            {
                var filePath = await _botClient.GetFileAsync(update.Message.Document.FileId);

                var result = await _yandexDiskService.SaveDocumentAsync(yandexToken, update.Message.Document.FileName, filePath.FilePath);

                if (result)
                {
                    _botClient.SendTextMessageAsync(update.Message.Chat.Id, "Файл успешно загружен!");
                }
                else
                {
                    _botClient.SendTextMessageAsync(update.Message.Chat.Id, "ошибка при загрузке файла :(");
                }
            }
            

           
        }


    }
}
