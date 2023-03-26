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
                        break;
                    case "/registration":
                        await ExecuteCommandAsync(CommandNames.Registration, update);
                        break;

                    case "/auth_yandex":
                        await ExecuteCommandAsync(CommandNames.YandexAuth, update);
                        break;
                }
                switch (update.Message?.Document?.MimeType)
                {
                    case "application/pdf":
                        await ExecuteCommandAsync(CommandNames.YandexDisk, update);
                        break;
                }
<<<<<<< HEAD
=======

                 if(update.Message.Document != null)
                {
                    await ExecuteCommandAsync(CommandNames.UploadFile, update);
                }

>>>>>>> 8052811ceaa234c42f0062de305fcb1e01cdd12f
            }
           


           
        }
        private async Task ExecuteCommandAsync(CommandNames name, Update update)
        {
            var command = _commands.FirstOrDefault(x => x.Name == name);
            await command.ExecuteAsync(update);
        }
    }
}
