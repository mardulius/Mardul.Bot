using Mardul.Bot.Services.BotService;
using Mardul.Bot.Services.CommandService;
using Mardul.Bot.Services.UserService;
using Mardul.Bot.Services.YandexAuthService;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Mardul.Bot.Controllers.Bot
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IYandexAuthService _yandexAuthService;
        private readonly IUserService _userService;
        public BotController(ICommandService commandService, IYandexAuthService yandexAuthService, IUserService userService)
        {
            _commandService = commandService;
            _yandexAuthService = yandexAuthService;
            _userService = userService;
        }

        [Route("1ZwWxG8wNBvLvUlncprlZG3l9q1RdseE")]
        [HttpPost]
        public async Task<IActionResult> UpdateMessage([FromBody] Update update)
        {
            await _commandService.ExecuteAsync(update);

            return Ok();
        }

        [Route("Auth")]
        [HttpGet]
        public async Task<IActionResult> GetToken(string code, string state)
        {
            if (state != null)
            {
                long userId = long.Parse(state);
                var user = await _userService.GetUserFromChatIdAsync(userId);
                if (user != null && user.YandexTokenId == 0)
                {
                    var token = await _yandexAuthService.GetTokenFromAuthorizationCodeAsync(code);

                    user.YandexToken = token;
                    _userService.SetYandexTokenAsync(user);
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}
