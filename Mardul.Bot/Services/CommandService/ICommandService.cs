using Telegram.Bot.Types;

namespace Mardul.Bot.Services.CommandService
{
    public interface ICommandService
    {
        Task ExecuteAsync(Update update);
    }
}
