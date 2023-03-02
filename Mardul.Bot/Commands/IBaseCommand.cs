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
        Registration
    }

}
