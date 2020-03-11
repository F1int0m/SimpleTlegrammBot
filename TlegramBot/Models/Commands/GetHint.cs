using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot.Models.Commands
{
    public class GetHint : Command
    {
        private const long rtfChatId = -1001391211198;
        public override string Name => "/gethint";
        public override async Task Execute(Message message, TelegramBotClient bot)
        {
            var chatId = message.Chat.Id;
            var userId = message.From.Id;
            var c = await bot.GetChatMemberAsync(rtfChatId, userId);
            if ((int)c.Status<3)
            {
                await bot.SendTextMessageAsync(chatId, "Ты подписан на нашу телегу");
                return;
            }
            await bot.SendTextMessageAsync(chatId, "Ты не подписан, а зря. Подпишись - https://t.me/rtf_urfu");
        }
    }
}