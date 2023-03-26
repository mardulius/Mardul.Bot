using Telegram.Bot.Types;

namespace Mardul.Bot.Commands
{
    public interface IBaseCommand
    {
        CommandNames Name { get; }
        Task ExecuteAsync(Update update);

    }

    public enum CommandNames
    {
        Start = 1,
        Registration,
<<<<<<< HEAD
        YandexAuth,
        YandexDisk
=======
        AuthYandex,
        UploadFile
>>>>>>> 8052811ceaa234c42f0062de305fcb1e01cdd12f
    }

}
