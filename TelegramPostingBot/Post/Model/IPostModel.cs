using System;
using System.Collections.Generic;
using System.Text;
using TelegramPostingBot.Post.Type;

namespace TelegramPostingBot.Post.Model
{
    interface IPostModel
    { 
        PostType Type { get; }
        
        string Text { get; set; }
        string[] Attachments { get; set; }
    }
}
