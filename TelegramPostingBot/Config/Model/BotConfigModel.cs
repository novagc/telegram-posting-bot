using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramPostingBot.Config.Model
{
    class BotConfigModel
    {
        public string BotToken { get; set; }
        public string[] TelegramChannels { get; set; }
    }
}
