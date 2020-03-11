using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Models.Commands;

namespace TlegramBot.Models.Commands
{
    public class Start : Command
    {
        public override string Name => "/start";
        
        public override async Task Execute(Message message, TelegramBotClient bot)
        {
            var chatId = message.Chat.Id;
            await bot.SendPhotoAsync(chatId, "https://pbs.twimg.com/media/BSvs99iIEAAYPaA?format=jpg&name=small", "Никита лапочка ^_^");
        }
    }
}