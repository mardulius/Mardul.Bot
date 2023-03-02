using Mardul.Bot.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Mardul.Bot.Services.CommandService
{
    public class CommandService : ICommandService
    {

        private readonly List<IBaseCommand> _commands;

        public CommandService(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<IBaseCommand>().ToList();
        }
        public async Task ExecuteAsync(Update update)
        {
            if (update.Message?.Chat?.Id == null)
                return;

            if(update.Type == UpdateType.Message)
            {
                switch(update.Message.Text)
                {
                    case "/start":
                        await ExecuteCommandAsync(CommandNames.Start, update);
                        return;
                    case "/registration":
                        await ExecuteCommandAsync(CommandNames.Registration, update);
                        return;
                }
            }
        }
        private async Task ExecuteCommandAsync(CommandNames name, Update update)
        {
            var command = _commands.FirstOrDefault(x => x.Name == name);
            await command.ExecuteAsync(update);
        }
    }
}
