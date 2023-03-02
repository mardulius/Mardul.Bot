using Mardul.Bot.Services.BotService;
using Mardul.Bot.Services.CommandService;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Controllers.Bot
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        //private readonly TelegramBotClient _botClient;
        private readonly ICommandService _commandService;
        public BotController(ICommandService commandService)
        {
           _commandService = commandService;
        }
        //[Route("1ZwWxG8wNBvLvUlncprlZG3l9q1RdseE")]
        //[HttpPost]
        //public async Task<IActionResult> UpdateMessage([FromBody] Update update)
        //{
        //    if (update == null) return Ok("нет сообщений");
        //    await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"простите, не понимаю :(");

        //    return Ok();
        //}

        [Route("1ZwWxG8wNBvLvUlncprlZG3l9q1RdseE")]
        [HttpPost]
        public async Task<IActionResult> UpdateMessage([FromBody] Update update)
        {
            await _commandService.ExecuteAsync(update);

            return Ok();
        }
    }
}
