using System;
using System.Collections.Generic;
using System.Text;
using TelegramPostingBot.Post.Model;

namespace TelegramPostingBot.Bot
{
    interface IBot
    {
        string BotToken { get; }
        string ChannelID { get; }

        void SendPost(IPostModel post);
    }
}
