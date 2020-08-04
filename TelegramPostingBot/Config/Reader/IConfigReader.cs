using System;
using System.Collections.Generic;
using System.Text;
using TelegramPostingBot.Config.Model;

namespace TelegramPostingBot.Config
{
    interface IConfigReader<T>
    {
        string ConfigPath { get; set; }

        T ParseConfig();
    }
}
