using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramBot.Models;

namespace TelegramBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();
            var correctInput = false;

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    correctInput = true;
                    await command.Execute(message,client);
                    break;
                }
            }
            if (!correctInput)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Не забывай, команды вводятся с /");
            }

            return Ok();
        }

    }
}
