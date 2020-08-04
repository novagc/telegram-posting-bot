using System;
using System.Collections.Generic;
using System.Text;
using TelegramPostingBot.Config.Model;

namespace TelegramPostingBot.Config
{
    interface IConfigReader<T> where T : class
    {
        string ConfigPath { get; set; }

        T ParseConfig();
    }
}
