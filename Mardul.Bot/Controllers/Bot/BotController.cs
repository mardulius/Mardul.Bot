using Mardul.Bot.Services.BotService;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Controllers.Bot
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly TelegramBotClient _botClient;

        public BotController(BotService botService)
        {
            _botClient = botService.GetBotAsync().Result;
        }
        [Route("1ZwWxG8wNBvLvUlncprlZG3l9q1RdseE")]
        [HttpPost]
        public async Task<IActionResult> UpdateMessage([FromBody] Update update)
        {
            if (update == null) return Ok("нет сообщений");
            await _botClient.SendTextMessageAsync(update.Message.Chat.Id, $"простите, не понимаю :(");

            return Ok();
        }
    }
}
